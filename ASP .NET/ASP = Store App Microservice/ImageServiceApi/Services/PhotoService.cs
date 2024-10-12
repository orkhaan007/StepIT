using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ImageServiceApi.Dtos;
using ImageServiceApi.Settings;

namespace ImageServiceApi.Services
{
    public class PhotoService : IPhotoService
    {
        private IConfiguration _configuration;
        private CloudinarySettings _cloudinarySettings;
        private Cloudinary _cloudinary;

        public PhotoService(IConfiguration configuration)
        {
            _configuration = configuration;
            _cloudinarySettings = _configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            Account account = new Account(_cloudinarySettings.CloudName,
                _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret);
            _cloudinary=new Cloudinary(account);
        }

        public async Task<string> UploadImageAsync(PhotoCreationDto dto)
        {
            var uploadedResult = new ImageUploadResult();
            var file = dto.File;
            if (file?.Length > 0)
            {
                using (var stream=file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadedResult=await _cloudinary.UploadAsync(uploadParams);

                    if(uploadedResult != null)
                    {
                        HttpClient httpClient = new HttpClient();
                        HttpResponseMessage response = new HttpResponseMessage();
                        await httpClient.GetAsync($"https://localhost:10787/api/log/{$"The Product was added to DataBase at {DateTime.UtcNow.ToShortDateString()} / {DateTime.UtcNow.ToLongTimeString()}"}");
                        return uploadedResult.Url.ToString();
                    }
                }
            }
            return "";
        }
    }
}
