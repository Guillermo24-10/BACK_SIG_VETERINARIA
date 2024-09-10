using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Categories;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Categories;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [HttpGet]
        [Route("List")]
        public async Task<ActionResult> GetAll([FromQuery] CategoriesListRequestDto request)
        {
            try
            {
                var response = await _categoryApplication.GetAll(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] CategoriesCreateRequestDto request)
        {
            try
            {
                var response = await _categoryApplication.CreateCategory(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                var response = await _categoryApplication.DeleteCategory(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
