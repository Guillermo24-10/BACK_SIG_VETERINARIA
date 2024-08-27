using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Consults;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Consults;
using SIG_VETERINARIA.Utilities;
using System.Data;

namespace SIG_VETERINARIA.Repository.Repository.Consults
{
    public class ConsultRepository : IConsultRepository
    {
        private readonly string _connectionString;
        public ConsultRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }
        public async Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_reason", request.reason);
                    parameters.Add("@p_antecedents", request.antecedents);
                    parameters.Add("@p_diseases", request.diseases);
                    parameters.Add("@p_next_consult", request.next_consult);
                    parameters.Add("@p_patient_id", request.patient_id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_CONSULT,parameters,commandType:CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteConsult(DeleteDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);

                using (var con = new SqlConnection(_connectionString))
                {
                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETE_CONSULT,parameters,commandType:CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            response.Item = Convert.ToInt32(lector["id"].ToString());
                            response.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            response.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? Message.DELETE : Message.ERROR_DELETE;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false; 
                response.MessageException=ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<ConsultListResponseDto>> GetConsults(ConsultListRequestDto request)
        {
            var response = new ResultDto<ConsultListResponseDto>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@p_indice", request.index);
                parameters.Add("@p_limit", request.limit);
                parameters.Add("@p_patient_id", request.patient_id);

                using (var con = new SqlConnection(_connectionString))
                {
                    response.Data = (List<ConsultListResponseDto>)await con.QueryAsync<ConsultListResponseDto>(Helpers.SP_LIST_CONSULTS, parameters, commandType: CommandType.StoredProcedure);
                }
                response.IsSuccess = true;
                response.Message = response.Data.Count > 0 ? Message.QUERY : Message.QUERY_EMPTY;
                response.Total = response.Data.Count > 0 ? response.Data[0].totalRecords : 0;
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
