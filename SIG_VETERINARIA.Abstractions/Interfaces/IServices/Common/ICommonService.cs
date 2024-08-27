using Microsoft.AspNetCore.Http;
using SIG_VETERINARIA.DTOs.DTOs.Clients;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IServices.Common
{
    public interface ICommonService
    {
        public Task<ClientResultUploadImageDto> SaveImage(IFormFile image);
        public Task<string> DeleteImage(string publicId);
    }
}
