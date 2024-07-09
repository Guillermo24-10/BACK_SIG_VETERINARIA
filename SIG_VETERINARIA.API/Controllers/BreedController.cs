using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Breed;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Breeds;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly IBreedApplication _breedApplication;

        public BreedController(IBreedApplication breedApplication)
        {
            _breedApplication = breedApplication;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ListarBreed([FromQuery] BreedListRequestDto request)
        {
            try
            {
                var response = await _breedApplication.GetBreeds(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateBreed([FromBody] BreedCreateRequestDto request)
        {
            try
            {
                var response = await _breedApplication.CreateBreed(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteBreed([FromQuery] DeleteDto request)
        {
            try
            {
                var response = await _breedApplication.DeleteBreed(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
