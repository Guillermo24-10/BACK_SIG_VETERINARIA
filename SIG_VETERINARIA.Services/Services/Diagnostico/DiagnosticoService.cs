using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Diagnostico;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Diagnostico;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Diagnosticos;

namespace SIG_VETERINARIA.Services.Services.Diagnostico
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private readonly IDiagnosticoRepository _diagnosticoRepository;

        public DiagnosticoService(IDiagnosticoRepository diagnosticoRepository)
        {
            _diagnosticoRepository = diagnosticoRepository;
        }

        public async Task<ResultDto<int>> CreateDiagnostico(DiagnosticoCreateRequestDto request)
        {
            return await _diagnosticoRepository.CreateDiagnostico(request);
        }

        public async Task<ResultDto<int>> DeleteDiagnostico(DeleteDto request)
        {
            return await _diagnosticoRepository.DeleteDiagnostico(request);
        }

        public async Task<ResultDto<DiagnosticoListResponseDto>> GetDiagnosticos(DiagnosticoListRequestDto request)
        {
            return await _diagnosticoRepository.GetDiagnosticos(request);
        }
    }
}
