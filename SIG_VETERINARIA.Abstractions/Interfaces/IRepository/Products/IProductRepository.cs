using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Products;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Products
{
    public interface IProductRepository
    {
        public Task<ResultDto<ProductListResponseDto>> GetProducts(ProductListRequestDto request);
        public Task<ResultDto<int>> CreateProduct(ProductCreateRequestDto request);
        public Task<ResultDto<int>> DeleteProduct(DeleteDto request);
        public Task<ResultDto<ProductListResponseDto>> GetProductDetail(DeleteDto request);
    }
}
