namespace SIG_VETERINARIA.DTOs.DTOs.Clients
{
    public class ClientDetailResponseDto
    {
        public int id { get; set; }
        public string names { get; set; } = string.Empty;
        public string lastnames { get; set; } = string.Empty;
        public string photo { get; set; } = string.Empty;
        public string document_number { get; set; } = string.Empty;
        public string document_type { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string addres { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int totalRegisters { get; set; }
        public string public_id {  get; set; } = string.Empty;
        public string signature {  get; set; } = string.Empty;
    }
}
