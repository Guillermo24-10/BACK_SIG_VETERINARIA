using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Tratamiento
{
    public interface IProductsTratamientoApplication
    {
        public Task<ResultDto<ProductsTratamientoListResponseDto>> GetProductsTratamiento(ProductsTratamientoListRequestDTO request);
        public Task<ResultDto<int>> CreateProductTratamiento(List<ProductsTratamientoCreateRequestDto> request);
        public Task<ResultDto<int>> DeleteProductTratamiento(DeleteDto request);
    }
}
