namespace SIG_VETERINARIA.DTOs.DTOs.Breeds
{
    public class BreedCreateRequestDto
    {
        public int id {  get; set; }
        public string name { get; set; } = string.Empty;
        public int specie_id { get; set; }
    }
}
