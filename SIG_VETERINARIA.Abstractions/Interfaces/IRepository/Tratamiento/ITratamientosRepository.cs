using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Tratamiento
{
    public interface ITratamientosRepository
    {
        public Task<ResultDto<TratamientoListResponseDto>> ListTratamientos(TratamientoListRequestDto request);
        public Task<ResultDto<int>> CreateTratamiento(TratamientoCreateRequestDto request);
        public Task<ResultDto<int>> DeleteTratamiento(DeleteDto request);
    }
}
