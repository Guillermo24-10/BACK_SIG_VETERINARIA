using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Consults;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Consults;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Consults;

namespace SIG_VETERINARIA.Application.Application.Consults
{
    public class ConsultApplication : IConsultApplication
    {
        private readonly IConsultService _consultService;

        public ConsultApplication(IConsultService consultService)
        {
            _consultService = consultService;
        }

        public async Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDto request)
        {
            return await _consultService.CreateConsult(request);
        }

        public async Task<ResultDto<int>> DeleteConsult(DeleteDto request)
        {
            return await _consultService.DeleteConsult(request);
        }

        public async Task<ResultDto<ConsultListResponseDto>> GetConsults(ConsultListRequestDto request)
        {
            return await _consultService.GetConsults(request);
        }
    }
}
