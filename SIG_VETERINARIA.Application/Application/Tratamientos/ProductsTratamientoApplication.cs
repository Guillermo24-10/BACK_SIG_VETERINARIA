using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Tratamiento;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Tratamiento;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Application.Application.Tratamientos
{
    public class ProductsTratamientoApplication : IProductsTratamientoApplication
    {
        private readonly IProductsTratamientoService _productsTratamientoService;

        public ProductsTratamientoApplication(IProductsTratamientoService productsTratamientoService)
        {
            _productsTratamientoService = productsTratamientoService;
        }

        public async Task<ResultDto<int>> CreateProductTratamiento(List<ProductsTratamientoCreateRequestDto> request)
        {
            return await _productsTratamientoService.CreateProductTratamiento(request);
        }

        public async Task<ResultDto<int>> DeleteProductTratamiento(DeleteDto request)
        {
            return await _productsTratamientoService.DeleteProductTratamiento(request);
        }

        public async Task<ResultDto<ProductsTratamientoListResponseDto>> GetProductsTratamiento(ProductsTratamientoListRequestDTO request)
        {
            return await _productsTratamientoService.GetProductsTratamiento(request);
        }
    }
}
