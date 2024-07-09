using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Breed;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Breed;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Breeds;

namespace SIG_VETERINARIA.Services.Services.Breed
{
    public class BreedService : IBreedService
    {
        private readonly IBreedRepository _repository;

        public BreedService(IBreedRepository repository)
        {
            _repository = repository;
        }

        public Task<ResultDto<int>> CreateBreed(BreedCreateRequestDto request)
        {
            return _repository.CreateBreed(request);
        }

        public async Task<ResultDto<int>> DeleteBreed(DeleteDto request)
        {
            return await _repository.DeleteBreed(request);
        }

        public async Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDto request)
        {
            return await _repository.GetBreeds(request);
        }
    }
}
