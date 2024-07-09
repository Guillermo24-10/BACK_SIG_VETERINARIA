namespace SIG_VETERINARIA.DTOs.DTOs.User
{
    public class UserCreateRequestDto
    {
        public int id { get; set; }
        public string username { get; set; } = string.Empty;
        public string? password { get; set; }
        public int role_id { get; set; }
        public DateTime create_date { get; set; } = DateTime.Now;
    }
}
