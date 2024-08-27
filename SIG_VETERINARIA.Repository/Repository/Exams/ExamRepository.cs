using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Exams;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Exams;
using SIG_VETERINARIA.Utilities;
using System.Data;

namespace SIG_VETERINARIA.Repository.Repository.Exams
{
    public class ExamRepository : IExamRepository
    {
        private readonly string _connectionString;
        public ExamRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }
        public async Task<ResultDto<int>> CreateExam(ExamCreateRequestDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_id", request.id);
                    param.Add("@p_mucosa", request.mucosa);
                    param.Add("@p_piel", request.piel);
                    param.Add("@p_conjuntival", request.conjuntival);
                    param.Add("@p_oral", request.oral);
                    param.Add("@p_sis_reproductor", request.sis_reproductor);
                    param.Add("@p_rectal", request.rectal);
                    param.Add("@p_ojo", request.ojos);
                    param.Add("@p_nodulos_linfaticos", request.nodulos_linfaticos);
                    param.Add("@p_locomocion", request.locomocion);
                    param.Add("@p_sis_cardiovascular", request.sis_cardiovascular);
                    param.Add("@p_sis_respiratorio", request.sis_respiratorio);
                    param.Add("@p_sis_digestivo", request.sis_digestivo);
                    param.Add("@p_sis_urinario", request.sis_urinario);
                    param.Add("@p_id_consulta", request.consult_id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_EXAMS, param, commandType: CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteExam(DeleteDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                var param = new DynamicParameters();
                param.Add("@p_id", request.id);

                using (var con = new SqlConnection(_connectionString))
                {
                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETE_EXAM,param,commandType:CommandType.StoredProcedure))
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
                response.MessageException = ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<ExamListResponseDto>> GetExams(ExamListRequestDto request)
        {
            var response = new ResultDto<ExamListResponseDto>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_index", request.index);
                    param.Add("@p_limit", request.limit);
                    param.Add("@p_consult_id", request.consult_id);

                    response.Data = (List<ExamListResponseDto>)await con.QueryAsync<ExamListResponseDto>(Helpers.SP_LIST_EXAMS, param, commandType: CommandType.StoredProcedure);
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
