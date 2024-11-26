using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IServices.Tratamiento
{
    public interface ITratamientosService
    {
        public Task<ResultDto<TratamientoListResponseDto>> ListTratamientos(TratamientoListRequestDto request);
        public Task<ResultDto<int>> CreateTratamiento(TratamientoCreateRequestDto request);
        public Task<ResultDto<int>> DeleteTratamiento(DeleteDto request);
    }
}
