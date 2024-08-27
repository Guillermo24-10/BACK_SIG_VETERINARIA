using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Patients;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Common;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Patients;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Patients;

namespace SIG_VETERINARIA.Services.Services.Patients
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ICommonService _commonService;

        public PatientService(IPatientRepository patientRepository, ICommonService commonService)
        {
            _patientRepository = patientRepository;
            _commonService = commonService;
        }

        public async Task<ResultDto<int>> CreatePatient(PatientCreateRequestDto request)
        {
            if (request.photo != null)
            {
                var response = await _commonService.SaveImage(request.photo);
                if (response.isSuccess)
                {
                    request.uri_photo = response.uploadResult?.SecureUrl.ToString();
                    request.public_id = response.uploadResult?.PublicId;
                }
            }
            return await _patientRepository.CreatePatient(request);
        }

        public async Task<ResultDto<int>> DeletePatient(DeleteDto request)
        {
            var patient = await _patientRepository.GetPatientDetail(request);
            await _commonService.DeleteImage(patient.Item!.public_id!);
            return await _patientRepository.DeletePatient(request);
        }

        public async Task<ResultDto<PatientListResponseDto>> GetPatients(PatientLisRequestDto request)
        {
            return await _patientRepository.GetPatients(request);
        }
    }
}
