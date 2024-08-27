using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Patients;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Patients;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientApplication _patientApplication;

        public PatientController(IPatientApplication patientApplication)
        {
            _patientApplication = patientApplication;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetPatients([FromQuery]PatientLisRequestDto request)
        {
            try
            {
                var response = await _patientApplication.GetPatients(request);
                return Ok(response);
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreatePatient([FromForm] PatientCreateRequestDto request)
        {
            try
            {
                var response = await _patientApplication.CreatePatient(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeletePatient([FromQuery] DeleteDto request)
        {
            try
            {
                var response = await _patientApplication.DeletePatient(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
    }
}
