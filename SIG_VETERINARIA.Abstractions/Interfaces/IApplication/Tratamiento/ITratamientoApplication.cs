using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Tratamiento
{
    public interface ITratamientoApplication
    {
        public Task<ResultDto<TratamientoListResponseDto>> ListTratamientos(TratamientoListRequestDto request);
        public Task<ResultDto<int>> CreateTratamiento(TratamientoCreateRequestDto request);
        public Task<ResultDto<int>> DeleteTratamiento(DeleteDto request);
    }
}
