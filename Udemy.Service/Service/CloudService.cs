using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Udemy.Service.Helper;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class CloudService : ICloudService
    {
        private readonly Cloudinary _cloudinary;
        public CloudService(IOptions<CloudSetting> cloudinaryConfig)
        {
            var account = new Account(
           cloudinaryConfig.Value.CloudName,
           cloudinaryConfig.Value.ApiKey,
           cloudinaryConfig.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }
        public async Task<string> UploadImageAsync(IFormFile file)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                Transformation = new Transformation().Quality("auto").FetchFormat("auto")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new Exception($"Image upload failed: {uploadResult.Error.Message}");
            }

            return uploadResult.SecureUrl.ToString();
        }

        public async Task<string> UploadVideoAsync(IFormFile file)
        {
            // For videos, we need to use UploadAsync with explicit resource type
            var uploadParams = new RawUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams, "video");

            if (uploadResult.Error != null)
            {
                throw new Exception($"Video upload failed: {uploadResult.Error.Message}");
            }

            return uploadResult.SecureUrl.ToString();
        }

    }
}
