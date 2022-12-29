namespace IFS.DB.WebApp.Models.FileUpload;

public class UploadPhotoModel
{
    public DateTime? UploadTime { get; set; }
    public string Base64Encode { get; set; }
    public string ResizedBase64Encode { get; set; }
    public string Extension { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public double FileSizeInMb { get; set; }
}
