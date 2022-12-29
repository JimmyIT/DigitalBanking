using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Models.FileUpload;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace IFS.DB.WebApp.Shared.Components;

public partial class UploadPhotoComponent 
{
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;

    private InputFile _inputFile;
    private IBrowserFile? _browserFile;
    private EditContext _editContext;
    private UploadPhotoModel _uploadPhotoModel;

    protected override async Task OnInitializedAsync()
    {
        await PrepareUI_Async();
    }

    private async Task CancelAsync() => await BlazoredModal.CancelAsync();
    private async Task OkAsync()
    {
        if (!_isUploaded || _fileSizeError || _fileTypeError)
        {
            return;
        }

        await BlazoredModal.CloseAsync(ModalResult.Ok(_uploadPhotoModel));
    }

    private async Task PrepareUI_Async()
    {
        _uploadPhotoModel = new UploadPhotoModel();
        _editContext = new EditContext(_uploadPhotoModel);
    }

    #region Variable Declaration

    private bool _isUploaded = false;
    private bool _fileSizeError = false;
    private bool _fileTypeError = false;

    const int _maxFileSizeMB = 5;
    const int _maxAllowFileSize = _maxFileSizeMB * 1024 * 1024; // 5MB
    private double _fileSize = 0;
    private string _hoverClass;
    private string _fileBase64Encode = string.Empty;
    private string _resizedFileBase64Encode = string.Empty;
    List<string> _acceptedFileTypes = new List<string>() { "image/png", "image/jpeg" };

    #endregion

    #region Upload Events

    void OnDragEnter(DragEventArgs e) => _hoverClass = "hover";
    void OnDragLeave(DragEventArgs e) => _hoverClass = string.Empty;

    private async Task OnFileChange(InputFileChangeEventArgs e)
    {
        _browserFile = e.File;

        string fileRoute = @"E:\Testing-Places";
        fileRoute = $"{fileRoute}\\{_browserFile.Name}";
        int size = 0;

        using MemoryStream memoryStream = new MemoryStream();
        await _browserFile.OpenReadStream().CopyToAsync(memoryStream);
        using (Image srcImg = Image.FromStream(memoryStream))
        {
            int min = Math.Min(srcImg.Width, srcImg.Height);

            if (0 < size && size <= min)
                min = size;

            int x = CalXY(srcImg.Width, min);
            int y = CalXY(srcImg.Height, min);

            Rectangle srcForm = new Rectangle(x, y, min, min);

            // Create a new image at the cropped size
            Bitmap cropped = new Bitmap(min, min);

            Rectangle croppedForm = new Rectangle(0, 0, min, min);

            //// Create a Graphics object to do the drawing, *with the new bitmap as the target*
            using (Graphics g = Graphics.FromImage(cropped))
            {
                // Draw the desired area of the original into the graphics object
                g.DrawImage(
                    srcImg,
                    croppedForm,
                    srcForm,
                    GraphicsUnit.Pixel);

                _fileBase64Encode = $"data:image/jpeg;base64,{ToBase64String(cropped, ImageFormat.Jpeg)}";
                _isUploaded = true;
            }
        }

        await MapToFileUploadResultModelAsync();
    }

    private int CalXY(int widthOrHeight, int size)
    {
        if (widthOrHeight == size)
            return 0;
        else
            return (widthOrHeight - size) / 2;
    }

    public string ToBase64String(Bitmap bmp, ImageFormat imageFormat)
    {
        MemoryStream memoryStream = new MemoryStream();
        bmp.Save(memoryStream, imageFormat);
        memoryStream.Position = 0;
        byte[] byteBuffer = memoryStream.ToArray();
        memoryStream.Close();
        string base64String = Convert.ToBase64String(byteBuffer);
        return base64String;
    }
       
    #endregion

    private async Task MapToFileUploadResultModelAsync()
    {
        _uploadPhotoModel.Base64Encode = _fileBase64Encode;
        _uploadPhotoModel.ResizedBase64Encode = _resizedFileBase64Encode;
        _uploadPhotoModel.Extension = _browserFile.ContentType;
        _uploadPhotoModel.FileName = _browserFile.Name;
        _uploadPhotoModel.FileSizeInMb = _fileSize;
        _uploadPhotoModel.UploadTime = DateTime.Now;
    }

    private async Task CopyAsyncDocuments(string fileName, IBrowserFile? file)
    {
        string fileRoute = @"E:\Testing-Places";
        fileRoute = $"{fileRoute}\\{fileName}";
        await using FileStream fs = new(fileRoute, FileMode.Create);
        await file.OpenReadStream(maxAllowedSize: _maxAllowFileSize).CopyToAsync(fs); // maxAllowedSize in bytes
        fs.Close();
    }

}
