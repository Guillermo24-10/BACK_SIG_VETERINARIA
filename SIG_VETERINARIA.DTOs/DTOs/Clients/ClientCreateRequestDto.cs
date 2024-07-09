using Microsoft.AspNetCore.Http;

namespace SIG_VETERINARIA.DTOs.DTOs.Clients
{
    public class ClientCreateRequestDto
    {
        public int id {  get; set; }
        public string name { get; set; } = string.Empty;
        public string lastnames { get; set; } = string.Empty;
        public IFormFile? photo {  get; set; }
        public string document_number { get; set; } = string.Empty;
        public string document_type { get; set; } = string.Empty;
        public string? phone { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? email { get; set; }
        public string? uri_photo { get; set; }

        public string? public_id { get; set; }
        public string? signature { get; set; }
    }
}
