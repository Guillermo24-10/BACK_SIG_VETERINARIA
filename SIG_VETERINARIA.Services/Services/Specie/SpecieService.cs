using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Specie;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Specie;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Species;

namespace SIG_VETERINARIA.Services.Services.Specie
{
    public class SpecieService : ISpecieService
    {
        private ISpeciesRepository _speciesRepository;

        public SpecieService(ISpeciesRepository speciesRepository)
        {
            _speciesRepository = speciesRepository;
        }

        public async Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request)
        {
            return await _speciesRepository.CreateSpecie(request);
        }

        public async Task<ResultDto<int>> DeleteSpecie(DeleteDto request)
        {
            return await _speciesRepository.DeleteSpecie(request);
        }

        public async Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request)
        {
            return await _speciesRepository.GetAll(request);
        }
    }
}
