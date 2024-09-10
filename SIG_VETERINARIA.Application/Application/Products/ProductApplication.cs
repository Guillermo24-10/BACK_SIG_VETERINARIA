using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Products;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Products;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Products;

namespace SIG_VETERINARIA.Application.Application.Products
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductService _productService;

        public ProductApplication(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ResultDto<int>> CreateProduct(ProductCreateRequestDto request)
        {
            return await _productService.CreateProduct(request);
        }

        public async Task<ResultDto<int>> DeleteProduct(DeleteDto request)
        {
            return await _productService.DeleteProduct(request);
        }

        public async Task<ResultDto<ProductListResponseDto>> GetProducts(ProductListRequestDto request)
        {
            return await _productService.GetProducts(request);
        }
    }
}
