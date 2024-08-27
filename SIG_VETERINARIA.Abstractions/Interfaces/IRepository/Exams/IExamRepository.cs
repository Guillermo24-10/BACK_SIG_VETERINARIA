﻿using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Exams;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Exams
{
    public interface IExamRepository
    {
        public Task<ResultDto<ExamListResponseDto>> GetExams(ExamListRequestDto request);
        public Task<ResultDto<int>> CreateExam(ExamCreateRequestDto request);
        public Task<ResultDto<int>> DeleteExam(DeleteDto request);
    }
}
