namespace SIG_VETERINARIA.DTOs.DTOs.Products
{
    public class ProductListResponseDto
    {
        public string name {  get; set; } = string.Empty;
        public decimal cost { get; set; }
        public  decimal price { get; set; }
        public int stock {  get; set; }
        public string proveedor { get; set; } = string.Empty;
        public string status_product { get; set; } = string.Empty;
        public int category_id { get; set; }
        public string photo { get; set; } = string.Empty;
        public string public_id { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public int totalRecords { get; set; }
    }
}
