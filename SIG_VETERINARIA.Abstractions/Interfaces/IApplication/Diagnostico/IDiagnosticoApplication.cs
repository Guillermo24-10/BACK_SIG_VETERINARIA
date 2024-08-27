using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Diagnosticos;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Diagnostico
{
    public interface IDiagnosticoApplication
    {
        public Task<ResultDto<DiagnosticoListResponseDto>> GetDiagnosticos(DiagnosticoListRequestDto request);
        public Task<ResultDto<int>> CreateDiagnostico(DiagnosticoCreateRequestDto request);
        public Task<ResultDto<int>> DeleteDiagnostico(DeleteDto request);
    }
}
