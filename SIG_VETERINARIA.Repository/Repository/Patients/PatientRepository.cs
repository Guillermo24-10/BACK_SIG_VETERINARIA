using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Patients;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Patients;
using SIG_VETERINARIA.Utilities;
using System.Data;

namespace SIG_VETERINARIA.Repository.Repository.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }

        public async Task<ResultDto<int>> CreatePatient(PatientCreateRequestDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_names", request.names);
                    parameters.Add("@p_photo", request.uri_photo);
                    parameters.Add("@p_birthday", request.birthday);
                    parameters.Add("@p_age", request.age);
                    parameters.Add("@p_sex", request.sex);
                    parameters.Add("@p_color", request.color);
                    parameters.Add("@p_fur", request.fur);
                    parameters.Add("@p_particularity", request.particularity);
                    parameters.Add("@p_allergy", request.allergy);
                    parameters.Add("@p_breed_id", request.breed_id);
                    parameters.Add("@p_client", request.client_id);
                    parameters.Add("@p_public_id", request.public_id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_PATIENT, parameters, commandType: CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            response.Item = Convert.ToInt32(lector["id"].ToString());
                            response.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            response.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? Message.SAVE : Message.ERROR_SAVE;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.MessageException = ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<int>> DeletePatient(DeleteDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETE_PATIENT, parameters, commandType: CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            response.IsSuccess = true;
                            response.Item = Convert.ToInt32(lector["id"].ToString());
                            response.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? Message.DELETE : Message.ERROR_DELETE;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.MessageException = ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<PatientListResponseDto>> GetPatientDetail(DeleteDto request)
        {
            var response = new ResultDto<PatientListResponseDto>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    var query = await con.QueryAsync<PatientListResponseDto>(Helpers.SP_GET_PATIENT, parameters, commandType: CommandType.StoredProcedure);
                    response.Item = query!.Any() ? query.FirstOrDefault() : null;
                    response.IsSuccess = true;
                    response.Message = query!.Any() ? Message.QUERY : Message.QUERY_EMPTY;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.MessageException = ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<PatientListResponseDto>> GetPatients(PatientLisRequestDto request)
        {
            var response = new ResultDto<PatientListResponseDto>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_indice", request.index);
                    parameters.Add("@p_limit", request.limit);
                    parameters.Add("@p_client_id", request.client_id);

                    response.Data = (List<PatientListResponseDto>)await con.QueryAsync<PatientListResponseDto>(Helpers.SP_LIST_PATIENTS, parameters, commandType: CommandType.StoredProcedure);
                }
                response.IsSuccess = true;
                response.Message = response.Data.Count > 0 ? Message.QUERY : Message.QUERY_EMPTY;
                response.Total = response.Data.Count > 0 ? response.Data[0].totalRegisters : 0;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.MessageException = ex.Message;
            }

            return response;
        }
    }
}
