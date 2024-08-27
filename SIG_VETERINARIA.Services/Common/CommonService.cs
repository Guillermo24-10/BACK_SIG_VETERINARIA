using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Common;
using SIG_VETERINARIA.DTOs.DTOs.Clients;

namespace SIG_VETERINARIA.Services.Common
{
    public class CommonService : ICommonService
    {
        private readonly string _clouddinaryUri;

        public CommonService(IConfiguration configuration)
        {
            _clouddinaryUri = configuration.GetSection("cloudinary:URL").Value!;
        }
        public async Task<ClientResultUploadImageDto> SaveImage(IFormFile image)
        {
            var response = new ClientResultUploadImageDto();
            try
            {
                Cloudinary cloudinary = new Cloudinary(_clouddinaryUri);
                var fileWithPath = Path.Combine("Uploads", image.FileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                image.CopyTo(stream);
                stream.Close();
                var uploadsParams = new ImageUploadParams()
                {
                    File = new FileDescription(fileWithPath),
                    UseFilename = true,
                    Overwrite = true,
                    Folder = "sig_veterinary"
                };
                var uploadResult = await cloudinary.UploadAsync(uploadsParams);
                File.Delete(fileWithPath);
                response.isSuccess = true;
                response.uploadResult = uploadResult;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.messageException = ex.Message;
            }

            return response;
        }

        public async Task<string> DeleteImage(string publicId)
        {
            try
            {
                Cloudinary cloudinary = new Cloudinary(_clouddinaryUri);
                var deletionParam = new DeletionParams(publicId);
                var result = await cloudinary.DestroyAsync(deletionParam);
                return result.Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
