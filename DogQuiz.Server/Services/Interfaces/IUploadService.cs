namespace DogQuiz.Server.Services.Interfaces;

public interface IUploadService
{
    Task<string> UploadFile(Stream fileStream, string fileName);
    Task<bool> DeleteFile(string fileUrl);
    Task<string> GetFileUrl(string fileName);

    Task<string> UploadImage(Stream imageStream, string fileName);
    Task<string> GetImageUrl(string fileName);
    Task<bool> DeleteImage(string imageUrl);
}
