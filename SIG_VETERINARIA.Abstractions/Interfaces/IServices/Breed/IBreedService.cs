using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Breeds;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IServices.Breed
{
    public interface IBreedService
    {
        public Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDto request);
        public Task<ResultDto<int>> CreateBreed(BreedCreateRequestDto request);
        public Task<ResultDto<int>> DeleteBreed(DeleteDto request);
    }
}
