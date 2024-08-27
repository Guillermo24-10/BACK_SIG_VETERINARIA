using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IServices.Patients
{
    public interface IPatientService
    {
        public Task<ResultDto<PatientListResponseDto>> GetPatients(PatientLisRequestDto request);
        public Task<ResultDto<int>> CreatePatient(PatientCreateRequestDto request);
        public Task<ResultDto<int>> DeletePatient(DeleteDto request);
    }
}
