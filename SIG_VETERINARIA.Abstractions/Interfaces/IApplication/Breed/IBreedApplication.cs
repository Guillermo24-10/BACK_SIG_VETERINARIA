using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Breeds;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Breed
{
    public interface IBreedApplication
    {
        public Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDto request);
        public Task<ResultDto<int>> CreateBreed(BreedCreateRequestDto request);
        public Task<ResultDto<int>> DeleteBreed(DeleteDto request);
    }
}
