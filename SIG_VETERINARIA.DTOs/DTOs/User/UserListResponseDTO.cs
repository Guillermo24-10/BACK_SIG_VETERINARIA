namespace SIG_VETERINARIA.DTOs.DTOs.User
{
    public class UserListResponseDTO
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public int role_id { get; set; }
        public int state { get; set; }
        public DateTime create_date { get; set; }
    }
}
