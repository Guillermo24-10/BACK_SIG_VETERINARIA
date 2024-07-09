using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Species;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Specie
{
    public interface ISpeciesRepository
    {
        public Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request);
        public Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request);
        public Task<ResultDto<int>> DeleteSpecie(DeleteDto request);
    }
}
