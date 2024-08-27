namespace SIG_VETERINARIA.DTOs.DTOs.Exams
{
    public class ExamListRequestDto
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;
        public int consult_id { get; set; }
    }
}
