using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Diagnosticos;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Diagnostico
{
    public interface IDiagnosticoRepository
    {
        public Task<ResultDto<DiagnosticoListResponseDto>> GetDiagnosticos(DiagnosticoListRequestDto request);
        public Task<ResultDto<int>> CreateDiagnostico(DiagnosticoCreateRequestDto request);
        public Task<ResultDto<int>> DeleteDiagnostico(DeleteDto request);
    }
}
