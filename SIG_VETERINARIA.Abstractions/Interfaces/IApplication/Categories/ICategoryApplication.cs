using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Categories;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Categories
{
    public interface ICategoryApplication
    {
        public Task<ResultDto<CategoriesListResponseDto>> GetAll(CategoriesListRequestDto request);
        public Task<ResultDto<int>> CreateCategory(CategoriesCreateRequestDto request);
        public Task<ResultDto<int>> DeleteCategory(DeleteDto request);
    }
}
