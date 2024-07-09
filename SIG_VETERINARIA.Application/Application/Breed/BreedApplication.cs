using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Breed;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Breed;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Breeds;

namespace SIG_VETERINARIA.Application.Application.Breed
{
    public class BreedApplication : IBreedApplication
    {
        private readonly IBreedService _breedService;

        public BreedApplication(IBreedService breedService)
        {
            _breedService = breedService;
        }

        public async Task<ResultDto<int>> CreateBreed(BreedCreateRequestDto request)
        {
            return await _breedService.CreateBreed(request);
        }

        public async Task<ResultDto<int>> DeleteBreed(DeleteDto request)
        {
            return await _breedService.DeleteBreed(request);
        }

        public async Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDto request)
        {
            return await _breedService.GetBreeds(request);
        }
    }
}
