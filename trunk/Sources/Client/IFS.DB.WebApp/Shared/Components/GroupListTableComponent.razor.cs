using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.GroupMaintenance;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class GroupListTableComponent
{
    [CascadingParameter] IModalService ModalSvc { get; set; } = default!;
    [Parameter] public bool ChangablePageSize { get; set; }
    [Parameter] 
    public SearchGroupModel SearchData 
    {
        get => this._searchData;
        set
        {
            this._searchData = value;
            new Task(async () =>
            {
                await LoadDataAsync();
            }).Start();
        }
    }
    private SearchGroupModel _searchData;

    private DataGridComponent<GroupInfoModel> _dataSourceGrid;
    private List<ColumnDefinition<GroupInfoModel>> _columnsDefinition;
    private PagingConfig _pagingConfig;
    private GroupMaintenanceModel _groupMaintenanceModel = new GroupMaintenanceModel();
    private int _pageIndex = 1;
    private int _pageSize = 5;

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);
        await base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        await InitializeDataSourceGrid();
        await LoadDataAsync();
        await base.OnInitializedAsync();
    }

    /// <summary>
    /// Call API to get data
    /// </summary>
    /// <returns></returns>
    private async Task<GroupMaintenanceModel> GetDataAsync() => FakeData.GroupMaintenance with { };

    /// <summary>
    /// load data to UI
    /// </summary>
    /// <returns></returns>
    private async Task LoadDataAsync()
    {
        _groupMaintenanceModel = await GetDataAsync();
        if(_searchData != null)
        {
            if (!string.IsNullOrEmpty(_searchData.SearchString))
            {
                _groupMaintenanceModel.Groups  = _groupMaintenanceModel.Groups.Where(x => x.Name.ToLower().Contains(_searchData.SearchString.ToLower())).ToList();
                _groupMaintenanceModel.TotalRecords  = _groupMaintenanceModel.Groups.Count;
            }

            if (_searchData.Groups?.Count > 0)
            {
                List<GroupInfoModel> groupInfoModels = new List<GroupInfoModel>();
                _searchData.Groups.ForEach(x =>
                {
                    if(_groupMaintenanceModel.Groups.Contains(x))
                    {
                        groupInfoModels.Add(x);
                    }
                });

                _groupMaintenanceModel.Groups = groupInfoModels;
                _groupMaintenanceModel.TotalRecords = groupInfoModels.Count;
            }
        }

        _groupMaintenanceModel.TotalRecords = _groupMaintenanceModel.Groups.Count;
        _groupMaintenanceModel.Groups = _groupMaintenanceModel.Groups.Skip(_pagingConfig.PageSize * (_pageIndex-1)).Take(_pageSize).ToList();
    }

    private async Task InitializeDataSourceGrid()
    {
        if (_columnsDefinition == null)
        {
            _columnsDefinition = new List<ColumnDefinition<GroupInfoModel>>();
            _columnsDefinition.AddRange(
            new ColumnDefinition<GroupInfoModel>[]{
                    new() { DataField = "Name", Caption="Group Name" },
                    new() { DataField = "Description", Caption="Description" },
                    new() { DataField = "TotalMembers", Caption="Amount of members" },
                    new() { Caption="", FragmentTemplateFunc = ButtonActionTemplate },
            });
        }

        _pagingConfig = new PagingConfig()
        {
            Enabled = true,
            PageSize = 5,
            CustomPager = false
        };
    }

    private async Task Delete(GroupInfoModel group)
    {
        ModalParameters parameters = new ModalParameters()
            .Add(nameof(GroupDeletionConfirmModalComponent.GroupInfo), group);

        var options = new ModalOptions
        {
            UseCustomLayout = true
        };

        var modalResult = ModalSvc.Show<GroupDeletionConfirmModalComponent>($"", parameters, options);
        var result = await modalResult.Result;
        if(result.Confirmed)
        {
            _groupMaintenanceModel.Groups.RemoveAll(x => x.ID == group.ID);
            _groupMaintenanceModel.TotalRecords = _groupMaintenanceModel.Groups.Count;

            FakeData.UserMaintenance.UserInfos.ForEach(user =>
            {
                if(user.GroupID == group.ID)
                {
                    user.GroupID = null;
                }
            });
        }
    }

    
    #region Invoke Pagination CallBack

    private async Task OnPrevPageChanged()
    {
        _pageIndex = _dataSourceGrid.GotoPrevPage();
        await LoadDataAsync();
    }

    private async Task OnPageSizeChanged(int pageSize)
    {
        _pageIndex = 1;
        _pageSize = pageSize;
        await LoadDataAsync();

        _groupMaintenanceModel.TotalRecords = _groupMaintenanceModel.Groups.Count;
        _groupMaintenanceModel.Groups = _groupMaintenanceModel.Groups.Skip(_pageSize * (_pageIndex - 1)).Take(_pageSize).ToList();
    }

    private async Task OnNextPageChanged()
    {
        _pageIndex = _dataSourceGrid.GotoNextPage();
        await LoadDataAsync();
    }

    private async Task OnPageIndexChanged(int pageIndex)
    {
        _pageIndex = pageIndex;
        await LoadDataAsync();
    }   

    #endregion
}
