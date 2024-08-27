using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Consults;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Consults;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Consults;

namespace SIG_VETERINARIA.Services.Services.Consults
{
    public class ConsultService : IConsultService
    {
        private readonly IConsultRepository _consultRepository;

        public ConsultService(IConsultRepository consultRepository)
        {
            _consultRepository = consultRepository;
        }

        public async Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDto request)
        {
            return await _consultRepository.CreateConsult(request);
        }

        public async Task<ResultDto<int>> DeleteConsult(DeleteDto request)
        {
            return await _consultRepository.DeleteConsult(request);
        }

        public async Task<ResultDto<ConsultListResponseDto>> GetConsults(ConsultListRequestDto request)
        {
            return await _consultRepository.GetConsults(request);
        }
    }
}
