using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Specie;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Species;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecieController : ControllerBase
    {
        private readonly ISpecieApplication _specieApplication;

        public SpecieController(ISpecieApplication specieApplication)
        {
            _specieApplication = specieApplication;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ListarSpecies([FromQuery] SpecieListRequestDto request)
        {
            try
            {
                var response = await _specieApplication.GetAll(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateSpecies([FromBody] SpecieCreateRequestDto request)
        {
            try
            {
                var response = await _specieApplication.CreateSpecie(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteSpecie([FromQuery] DeleteDto request)
        {
            try
            {
                var response = await _specieApplication.DeleteSpecie(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
