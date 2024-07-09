namespace SIG_VETERINARIA.DTOs.DTOs.Breeds
{
    public class BreedListResponseDto
    {
        public int id {  get; set; }
        public string name { get; set; } = string.Empty;
        public int status { get; set; }
        public int specie_id { get; set; }
        public string specie { get; set; } = string.Empty;
        public int totalRegisters { get; set; }
    }
}
