using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Patients;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Patients;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Patients;

namespace SIG_VETERINARIA.Application.Application.Patients
{
    public class PatientApplication : IPatientApplication
    {
        private readonly IPatientService _patientService;

        public PatientApplication(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<ResultDto<int>> CreatePatient(PatientCreateRequestDto request)
        {
            return await _patientService.CreatePatient(request);
        }

        public async Task<ResultDto<int>> DeletePatient(DeleteDto request)
        {
            return await _patientService.DeletePatient(request);
        }

        public async Task<ResultDto<PatientListResponseDto>> GetPatients(PatientLisRequestDto request)
        {
            return await _patientService.GetPatients(request);
        }
    }
}
