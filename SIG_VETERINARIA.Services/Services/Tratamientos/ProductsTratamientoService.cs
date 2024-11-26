using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Tratamiento;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Tratamiento;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Services.Services.Tratamientos
{
    public class ProductsTratamientoService : IProductsTratamientoService
    {
        private readonly IProductsTratamientoRepository _productsTratamientoRepository;

        public ProductsTratamientoService(IProductsTratamientoRepository productsTratamientoRepository)
        {
            _productsTratamientoRepository = productsTratamientoRepository;
        }

        public async Task<ResultDto<int>> CreateProductTratamiento(List<ProductsTratamientoCreateRequestDto> request)
        {
            return await _productsTratamientoRepository.CreateProductTratamiento(request);
        }

        public async Task<ResultDto<int>> DeleteProductTratamiento(DeleteDto request)
        {
            return await _productsTratamientoRepository.DeleteProductTratamiento(request);
        }

        public async Task<ResultDto<ProductsTratamientoListResponseDto>> GetProductsTratamiento(ProductsTratamientoListRequestDTO request)
        {
            return await _productsTratamientoRepository.GetProductsTratamiento(request);
        }
    }
}
