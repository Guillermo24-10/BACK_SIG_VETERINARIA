using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Species;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IServices.Specie
{
    public interface ISpecieService
    {
        public Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request);
        public Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request);
        public Task<ResultDto<int>> DeleteSpecie(DeleteDto request);
    }
}
