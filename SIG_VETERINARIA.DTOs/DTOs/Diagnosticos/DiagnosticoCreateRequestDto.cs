namespace SIG_VETERINARIA.DTOs.DTOs.Diagnosticos
{
    public class DiagnosticoCreateRequestDto
    {
        public int id {  get; set; }
        public string detalle { get; set; } = string.Empty;
        public DateTime fecha_diagnostico { get; set; }
        public int consult_id { get; set; }
    }
}
