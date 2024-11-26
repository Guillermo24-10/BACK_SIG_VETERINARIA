namespace SIG_VETERINARIA.DTOs.DTOs.Tratamientos
{
    public class ProductsTratamientoListResponseDto
    {
        public int id {  get; set; }
        public int tratamiento_id { get; set; }
        public int product_id { get; set; }
        public string name { get; set; } = string.Empty;
        public int totalRecords { get; set; }
    }
}
