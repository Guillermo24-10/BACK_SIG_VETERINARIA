using Microsoft.AspNetCore.Http;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Clients;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IServices.Clients
{
    public interface IClientService
    {
        public Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request);
        public Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request);
        public Task<ResultDto<int>> DeleteClient(DeleteDto request);
    }
}
