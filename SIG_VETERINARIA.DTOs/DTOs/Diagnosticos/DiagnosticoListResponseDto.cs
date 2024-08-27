namespace SIG_VETERINARIA.DTOs.DTOs.Diagnosticos
{
    public class DiagnosticoListResponseDto
    {
        public int id { get; set; }
        public string detalle {  get; set; } = string.Empty;
        public string fecha_diagnostico {  get; set; } = string.Empty;
        public int totalRecords { get; set; }
    }
}
