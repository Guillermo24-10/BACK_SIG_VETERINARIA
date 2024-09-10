using Microsoft.AspNetCore.Http;

namespace SIG_VETERINARIA.DTOs.DTOs.Products
{
    public class ProductCreateRequestDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public decimal price { get; set; }
        public decimal cost { get; set; }
        public int stock { get; set; }
        public string proveedor { get; set; } = string.Empty;
        public string status_product { get; set; } = string.Empty;
        public int category_id { get; set; }
        public IFormFile? photo { get; set; }
        public string public_id { get; set; } = string.Empty;
        public string uri_photo { get; set; } = string.Empty;
    }
}
