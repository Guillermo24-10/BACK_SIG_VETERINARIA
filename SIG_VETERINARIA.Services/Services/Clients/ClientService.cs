using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Clients;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Clients;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Common;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Clients;

namespace SIG_VETERINARIA.Services.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICommonService _commonService;
        private readonly string _clouddinaryUri;

        public ClientService(IClientRepository clientRepository, IConfiguration configuration, ICommonService commonService)
        {
            _clientRepository = clientRepository;
            _clouddinaryUri = configuration.GetSection("cloudinary:URL").Value!;
            _commonService = commonService;
        }

        public async Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request)
        {
            if (request.photo != null)
            {
                var res = await _commonService.SaveImage(request.photo!);
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
            await _commonService.DeleteImage(client.Item!.public_id);
            return await _clientRepository.DeleteClient(request);
        }

        public async Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request)
        {
            return await _clientRepository.GetClients(request);
        }
    }
}
