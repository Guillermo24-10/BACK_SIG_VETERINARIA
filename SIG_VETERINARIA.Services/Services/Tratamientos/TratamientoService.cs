using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Tratamiento;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Tratamiento;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Services.Services.Tratamientos
{
    public class TratamientoService : ITratamientosService
    {
        private readonly ITratamientosRepository _tratamientosRepository;

        public TratamientoService(ITratamientosRepository tratamientosRepository)
        {
            _tratamientosRepository = tratamientosRepository;
        }

        public Task<ResultDto<int>> CreateTratamiento(TratamientoCreateRequestDto request)
        {
            return _tratamientosRepository.CreateTratamiento(request);
        }

        public Task<ResultDto<int>> DeleteTratamiento(DeleteDto request)
        {
            return _tratamientosRepository.DeleteTratamiento(request);
        }

        public Task<ResultDto<TratamientoListResponseDto>> ListTratamientos(TratamientoListRequestDto request)
        {
            return _tratamientosRepository.ListTratamientos(request);
        }
    }
}
