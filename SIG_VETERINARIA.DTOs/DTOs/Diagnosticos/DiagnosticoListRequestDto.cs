namespace SIG_VETERINARIA.DTOs.DTOs.Diagnosticos
{
    public class DiagnosticoListRequestDto
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;
        public int consult_id { get; set; }
    }
}
