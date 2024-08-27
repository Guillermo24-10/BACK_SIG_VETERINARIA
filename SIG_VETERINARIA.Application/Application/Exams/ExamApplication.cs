using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Exams;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Exams;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Exams;

namespace SIG_VETERINARIA.Application.Application.Exams
{
    public class ExamApplication : IExamApplication
    {
        private readonly IExamService _examService;

        public ExamApplication(IExamService examService)
        {
            _examService = examService;
        }

        public async Task<ResultDto<int>> CreateExam(ExamCreateRequestDto request)
        {
            return await _examService.CreateExam(request);
        }

        public async Task<ResultDto<int>> DeleteExam(DeleteDto request)
        {
            return await _examService.DeleteExam(request);
        }

        public async Task<ResultDto<ExamListResponseDto>> GetExams(ExamListRequestDto request)
        {
            return await _examService.GetExams(request);    
        }
    }
}
