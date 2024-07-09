using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Clients;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Clients;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Clients;

namespace SIG_VETERINARIA.Services.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly string _clouddinaryUri;

        public ClientService(IClientRepository clientRepository, IConfiguration configuration)
        {
            _clientRepository = clientRepository;
            _clouddinaryUri = configuration.GetSection("cloudinary:URL").Value!;
        }

        public async Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request)
        {
            if (request.photo != null)
            {
                var res = await SaveImage(request.photo!);
                if (res.isSuccess)
                {
                    request.uri_photo = res.uploadResult?.SecureUrl.ToString();
                    request.signature = res.uploadResult?.Signature;
                    request.public_id = res.uploadResult?.PublicId;
                }
            }
            return await _clientRepository.CreateClient(request);
        }

        public async Task<ResultDto<int>> DeleteClient(DeleteDto request)
        {
            var client = await _clientRepository.GetClientDetail(request.id);
            await DeleteImage(client.Item!.public_id);
            return await _clientRepository.DeleteClient(request);
        }

        public async Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request)
        {
            return await _clientRepository.GetClients(request);
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
