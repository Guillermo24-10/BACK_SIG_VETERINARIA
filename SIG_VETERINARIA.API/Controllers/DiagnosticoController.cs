using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Diagnostico;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Diagnosticos;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoApplication _diagnosticoApplication;

        public DiagnosticoController(IDiagnosticoApplication diagnosticoApplication)
        {
            _diagnosticoApplication = diagnosticoApplication;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetDiagnosticos([FromQuery] DiagnosticoListRequestDto request)
        {
            try
            {
                var response = await _diagnosticoApplication.GetDiagnosticos(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateDiagnosticos(DiagnosticoCreateRequestDto request)
        {
            try
            {
                var response = await _diagnosticoApplication.CreateDiagnostico(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteDiagnostico([FromQuery] DeleteDto request)
        {
            try
            {
                var response = await _diagnosticoApplication.DeleteDiagnostico(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
