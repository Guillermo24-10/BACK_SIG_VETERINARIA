using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Categories;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IServices.Categories
{
    public interface ICategoryService
    {
        public Task<ResultDto<CategoriesListResponseDto>> GetAll(CategoriesListRequestDto request);
        public Task<ResultDto<int>> CreateCategory(CategoriesCreateRequestDto request);
        public Task<ResultDto<int>> DeleteCategory(DeleteDto request);
    }
}
