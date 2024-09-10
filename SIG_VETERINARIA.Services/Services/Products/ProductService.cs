using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Products;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Common;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Products;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Products;

namespace SIG_VETERINARIA.Services.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICommonService _commonService;

        public ProductService(IProductRepository repository, ICommonService commonService)
        {
            _repository = repository;
            _commonService = commonService;
        }

        public async Task<ResultDto<int>> CreateProduct(ProductCreateRequestDto request)
        {
            if (request.photo != null)
            {
                var res = await _commonService.SaveImage(request.photo);
                if (res.isSuccess)
                {
                    request.uri_photo = res.uploadResult!.SecureUrl.ToString();
                    request.public_id = res.uploadResult.PublicId;
                }
            }

            return await _repository.CreateProduct(request);
        }

        public async Task<ResultDto<int>> DeleteProduct(DeleteDto request)
        {
            var product = await _repository.GetProductDetail(request);
            await _commonService.DeleteImage(product.Item!.public_id!);

            return await _repository.DeleteProduct(request);
        }

        public async Task<ResultDto<ProductListResponseDto>> GetProducts(ProductListRequestDto request)
        {
            return await _repository.GetProducts(request);
        }
    }
}
