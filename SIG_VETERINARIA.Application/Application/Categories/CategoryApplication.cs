using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Categories;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Categories;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Categories;

namespace SIG_VETERINARIA.Application.Application.Categories
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryService _categoryService;

        public CategoryApplication(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ResultDto<int>> CreateCategory(CategoriesCreateRequestDto request)
        {
            return await _categoryService.CreateCategory(request);
        }

        public Task<ResultDto<int>> DeleteCategory(DeleteDto request)
        {
            return _categoryService.DeleteCategory(request);
        }

        public Task<ResultDto<CategoriesListResponseDto>> GetAll(CategoriesListRequestDto request)
        {
            return _categoryService.GetAll(request);
        }
    }
}
