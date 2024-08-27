using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Exams;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Exams;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamApplication _examApplication;

        public ExamController(IExamApplication examApplication)
        {
            _examApplication = examApplication;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetExams([FromQuery] ExamListRequestDto request)
        {
            try
            {
                var response = await _examApplication.GetExams(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateExam([FromBody] ExamCreateRequestDto request)
        {
            try
            {
                var response = await _examApplication.CreateExam(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteExam([FromQuery] DeleteDto request)
        {
            try
            {
                var response = await _examApplication.DeleteExam(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
