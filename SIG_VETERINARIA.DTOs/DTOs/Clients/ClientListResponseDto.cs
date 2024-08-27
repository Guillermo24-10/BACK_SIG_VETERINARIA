namespace SIG_VETERINARIA.DTOs.DTOs.Clients
{
    public class ClientListResponseDto
    {
        public int id {  get; set; }
        public string name { get; set; } = string.Empty;
        public string lastnames { get; set; } = string.Empty;   
        public string photo { get; set; } = string.Empty;
        public string document_number { get; set; } = string.Empty;     
        public string document_type { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string city {  get; set; } = string.Empty;
        public int totalRegisters { get; set; }
    }
}
