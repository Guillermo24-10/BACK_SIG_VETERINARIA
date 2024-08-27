using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Consults;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Consults;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private readonly IConsultApplication _consultApplication;

        public ConsultController(IConsultApplication consultApplication)
        {
            _consultApplication = consultApplication;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetConsults([FromQuery]ConsultListRequestDto request)
        {
            try
            {
                var response = await _consultApplication.GetConsults(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateConsult([FromBody] ConsultCreateRequestDto request)
        {
            try
            {
                var response = await _consultApplication.CreateConsult(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteConsult([FromQuery] DeleteDto request)
        {
            try
            {
                var response = await _consultApplication.DeleteConsult(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
