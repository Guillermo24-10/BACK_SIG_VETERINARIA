
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Categories;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Categories;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Categories;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Categories;

namespace SIG_VETERINARIA.Services.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResultDto<int>> CreateCategory(CategoriesCreateRequestDto request)
        {
            return await _categoryRepository.CreateCategory(request);
        }

        public Task<ResultDto<int>> DeleteCategory(DeleteDto request)
        {
            return _categoryRepository.DeleteCategory(request);
        }

        public Task<ResultDto<CategoriesListResponseDto>> GetAll(CategoriesListRequestDto request)
        {
            return _categoryRepository.GetAll(request);
        }
    }
}
