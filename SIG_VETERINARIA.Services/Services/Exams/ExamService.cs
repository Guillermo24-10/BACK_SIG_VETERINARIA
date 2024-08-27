using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Exams;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Exams;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Exams;

namespace SIG_VETERINARIA.Services.Services.Exams
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repository;

        public ExamService(IExamRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto<int>> CreateExam(ExamCreateRequestDto request)
        {
            return await _repository.CreateExam(request);
        }

        public async Task<ResultDto<int>> DeleteExam(DeleteDto request)
        {
            return await _repository.DeleteExam(request);
        }

        public async Task<ResultDto<ExamListResponseDto>> GetExams(ExamListRequestDto request)
        {
            return await _repository.GetExams(request);
        }
    }
}
