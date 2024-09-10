using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Categories;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Categories
{
    public interface ICategoryRepository
    {
        public Task<ResultDto<CategoriesListResponseDto>> GetAll(CategoriesListRequestDto request);
        public Task<ResultDto<int>> CreateCategory(CategoriesCreateRequestDto request);
        public Task<ResultDto<int>> DeleteCategory(DeleteDto request);
    }
}
