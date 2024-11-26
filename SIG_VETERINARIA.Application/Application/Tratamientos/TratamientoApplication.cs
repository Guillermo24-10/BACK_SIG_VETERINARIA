using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Tratamiento;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Tratamiento;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Application.Application.Tratamientos
{
    public class TratamientoApplication : ITratamientoApplication
    {
        private readonly ITratamientosService _tratamientosService;

        public TratamientoApplication(ITratamientosService tratamientosService)
        {
            _tratamientosService = tratamientosService;
        }

        public Task<ResultDto<int>> CreateTratamiento(TratamientoCreateRequestDto request)
        {
            return _tratamientosService.CreateTratamiento(request);
        }

        public Task<ResultDto<int>> DeleteTratamiento(DeleteDto request)
        {
            return _tratamientosService.DeleteTratamiento(request);
        }

        public Task<ResultDto<TratamientoListResponseDto>> ListTratamientos(TratamientoListRequestDto request)
        {
            return _tratamientosService.ListTratamientos(request);
        }
    }
}
