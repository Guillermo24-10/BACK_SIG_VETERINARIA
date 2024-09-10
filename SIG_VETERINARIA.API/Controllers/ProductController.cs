using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Products;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Products;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAll([FromQuery] ProductListRequestDto request)
        {
            try
            {
                var response = await _productApplication.GetProducts(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateRequestDto request)
        {
            try
            {
                var response = await _productApplication.CreateProduct(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteDto request)
        {
            try
            {
                var response = await _productApplication.DeleteProduct(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
