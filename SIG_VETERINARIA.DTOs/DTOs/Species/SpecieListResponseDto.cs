namespace SIG_VETERINARIA.DTOs.DTOs.Species
{
    public class SpecieListResponseDto
    {
        public int id {  get; set; }
        public string name { get; set; } = string.Empty;
        public DateTime create_date { get; set; }
        public int totalRegisters { get; set; }
    }
}
