using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Patients;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Patients
{
    public interface IPatientApplication
    {
        public Task<ResultDto<PatientListResponseDto>> GetPatients(PatientLisRequestDto request);
        public Task<ResultDto<int>> CreatePatient(PatientCreateRequestDto request);
        public Task<ResultDto<int>> DeletePatient(DeleteDto request);
    }
}
