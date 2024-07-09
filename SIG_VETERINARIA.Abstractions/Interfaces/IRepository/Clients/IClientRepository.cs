using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Clients;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Clients
{
    public interface IClientRepository
    {
        public Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request);
        public Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request);
        public Task<ResultDto<int>> DeleteClient(DeleteDto request);
        public Task<ResultDto<ClientDetailResponseDto>> GetClientDetail(int id);
    }
}
