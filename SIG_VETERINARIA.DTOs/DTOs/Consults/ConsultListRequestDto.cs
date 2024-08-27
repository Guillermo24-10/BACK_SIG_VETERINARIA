namespace SIG_VETERINARIA.DTOs.DTOs.Consults
{
    public class ConsultListRequestDto
    {
        public int index {  get; set; } = 0;
        public int limit { get; set; } = 10;
        public int patient_id {  get; set; }
    }
}
