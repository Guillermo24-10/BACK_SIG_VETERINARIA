using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Patients;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Patients
{
    public interface IPatientRepository
    {
        public Task<ResultDto<PatientListResponseDto>> GetPatients(PatientLisRequestDto request);
        public Task<ResultDto<int>> CreatePatient(PatientCreateRequestDto request);
        public Task<ResultDto<int>> DeletePatient(DeleteDto request);
        public Task<ResultDto<PatientListResponseDto>> GetPatientDetail(DeleteDto request);
    }
}
