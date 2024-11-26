namespace SIG_VETERINARIA.DTOs.DTOs.Tratamientos
{
    public class ProductsTratamiento
    {
        public int tratamiento_id { get; set; }
    }
    public class TratamientoCreateRequestDto
    {
        public int id {  get; set; }
        public string detalle { get; set; } = string.Empty;
        public int diagnostico_id { get; set; }
        public List<ProductsTratamientoCreateRequestDto> products { get; set; } = new List<ProductsTratamientoCreateRequestDto>();
    }
}
