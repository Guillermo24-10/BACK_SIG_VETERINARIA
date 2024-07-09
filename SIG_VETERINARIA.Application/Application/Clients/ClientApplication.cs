using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Clients;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Clients;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Clients;

namespace SIG_VETERINARIA.Application.Application.Clients
{
    public class ClientApplication : IClientApplication
    {
        private readonly IClientService _clientService;

        public ClientApplication(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request)
        {
            return await _clientService.CreateClient(request);
        }

        public async Task<ResultDto<int>> DeleteClient(DeleteDto request)
        {
            return await _clientService.DeleteClient(request);
        }

        public async Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request)
        {
            return await _clientService.GetClients(request);
        }
    }
}
