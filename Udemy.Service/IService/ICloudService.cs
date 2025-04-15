using Microsoft.AspNetCore.Http;

namespace Udemy.Service.IService
{
    public interface ICloudService
    {
        Task<string> UploadImageAsync(IFormFile file);
        Task<string> UploadVideoAsync(IFormFile file);
    }
}
