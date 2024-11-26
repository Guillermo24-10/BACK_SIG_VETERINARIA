namespace SIG_VETERINARIA.DTOs.DTOs.Tratamientos
{
    public class TratamientoListResponseDto
    {
        public int id {  get; set; }
        public string detalle {  get; set; } = string.Empty;
        public int diagnostico_id { get; set; }
        public int totalRecords {  get; set; }
    }
}
