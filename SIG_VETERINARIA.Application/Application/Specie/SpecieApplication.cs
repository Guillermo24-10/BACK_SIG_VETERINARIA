using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Specie;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Specie;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Species;

namespace SIG_VETERINARIA.Application.Application.Specie
{
    public class SpecieApplication : ISpecieApplication
    {
        public ISpecieService _specieService;

        public SpecieApplication(ISpecieService specieService)
        {
            _specieService = specieService;
        }

        public async Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request)
        {
            return await _specieService.CreateSpecie(request);
        }

        public async Task<ResultDto<int>> DeleteSpecie(DeleteDto request)
        {
            return await _specieService.DeleteSpecie(request);
        }

        public async Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request)
        {
            return await _specieService.GetAll(request);
        }
    }
}
