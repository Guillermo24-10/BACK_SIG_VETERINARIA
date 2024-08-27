using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Consults;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Consults
{
    public interface IConsultApplication
    {
        public Task<ResultDto<ConsultListResponseDto>> GetConsults(ConsultListRequestDto request);
        public Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDto request);
        public Task<ResultDto<int>> DeleteConsult(DeleteDto request);
    }
}
