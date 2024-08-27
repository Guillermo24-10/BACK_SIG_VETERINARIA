using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Diagnostico;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Diagnostico;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Diagnosticos;

namespace SIG_VETERINARIA.Application.Application.Diagnostico
{
    public class DiagnosticoApplication : IDiagnosticoApplication
    {
        private readonly IDiagnosticoService _diagnosticoService;

        public DiagnosticoApplication(IDiagnosticoService diagnosticoService)
        {
            _diagnosticoService = diagnosticoService;
        }

        public async Task<ResultDto<int>> CreateDiagnostico(DiagnosticoCreateRequestDto request)
        {
            return await _diagnosticoService.CreateDiagnostico(request);
        }

        public async Task<ResultDto<int>> DeleteDiagnostico(DeleteDto request)
        {
            return await _diagnosticoService.DeleteDiagnostico(request);
        }

        public async Task<ResultDto<DiagnosticoListResponseDto>> GetDiagnosticos(DiagnosticoListRequestDto request)
        {
            return await _diagnosticoService.GetDiagnosticos(request);
        }
    }
}
