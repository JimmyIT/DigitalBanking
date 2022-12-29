using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class PinComponent
{
    [Parameter]
    public bool IsSubmitting { get; set; }

    [Parameter]
    public List<string> Codes { get; set; }

    [Parameter]
    public EventCallback<List<string>> CodesChanged { get; set; }

    [Parameter]
    public bool ShowInvalid { get; set; }

    private List<string> _passwordCode = new();
    private Random _rnd = new();
    private List<int> _numbers = new();

    private const int NumDigitCode = 4;

    protected override void OnInitialized()
    {
        _numbers = Enumerable.Range(0, 10).OrderBy(x => _rnd.Next()).ToList();
    }

    private async Task Add(string value)
    {
        if (_passwordCode.Count >= NumDigitCode)
            return;

        _passwordCode.Add(value);

        if (CodesChanged.HasDelegate)
            await CodesChanged.InvokeAsync(_passwordCode);
    }

    private async Task RemoveLast()
    {
        if (_passwordCode.Count <= 0)
            return;

        _passwordCode.RemoveAt(_passwordCode.Count - 1);

        if (CodesChanged.HasDelegate)
            await CodesChanged.InvokeAsync(_passwordCode);
    }
}