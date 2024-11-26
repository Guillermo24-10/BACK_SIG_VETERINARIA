using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Tratamiento;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientosController : ControllerBase
    {
        private readonly ITratamientoApplication _tratamientoApplication;
        private readonly IProductsTratamientoApplication _productsTratamientoApplication;

        public TratamientosController(ITratamientoApplication tratamientoApplication, IProductsTratamientoApplication productsTratamientoApplication)
        {
            _tratamientoApplication = tratamientoApplication;
            _productsTratamientoApplication = productsTratamientoApplication;
        }

        [HttpGet]
        [Route("List")]
        public async Task<ActionResult> GetAll([FromQuery] TratamientoListRequestDto request)
        {
            try
            {
                var response = await _tratamientoApplication.ListTratamientos(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Save([FromBody] TratamientoCreateRequestDto request)
        {
            try
            {
                var response = await _tratamientoApplication.CreateTratamiento(request);
                //eliminar los productos del tratamiento
                await _productsTratamientoApplication.DeleteProductTratamiento(new DeleteDto { id = response.Item});
                //se obtiene el id del tratamiento
                request.products.ForEach(item =>
                {
                    item.tratamiento_id = response.Item;
                });
                await _productsTratamientoApplication.CreateProductTratamiento(request.products);
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
                var response = await _tratamientoApplication.DeleteTratamiento(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Products/list")]
        public async Task<ActionResult> ListProducts([FromQuery] ProductsTratamientoListRequestDTO request)
        {
            try
            {
                var response = await _productsTratamientoApplication.GetProductsTratamiento(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
