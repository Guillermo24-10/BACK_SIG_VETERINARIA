using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Diagnostico;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Diagnosticos;
using SIG_VETERINARIA.Utilities;
using System.Data;

namespace SIG_VETERINARIA.Repository.Repository.Diagnostico
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private readonly string _connectionString;

        public DiagnosticoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }

        public async Task<ResultDto<int>> CreateDiagnostico(DiagnosticoCreateRequestDto request)
        {
            var response = new ResultDto<int>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_id", request.id);
                    param.Add("@p_detalle", request.detalle);
                    param.Add("@p_fecha_diagnostico", request.fecha_diagnostico);
                    param.Add("@p_consult_id", request.consult_id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_DIAGNOSTICO,param,commandType:CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            response.Item = Convert.ToInt32(lector["id"].ToString());
                            response.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? Message.SAVE : Message.ERROR_SAVE;
                            response.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.MessageException = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ResultDto<int>> DeleteDiagnostico(DeleteDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_id", request.id);
                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETE_DIAGNOSTICO,param,commandType:CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            response.Item = Convert.ToInt32(lector["id"].ToString());
                            response.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? Message.DELETE : Message.ERROR_DELETE;
                            response.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.MessageException= ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<DiagnosticoListResponseDto>> GetDiagnosticos(DiagnosticoListRequestDto request)
        {
            var response = new ResultDto<DiagnosticoListResponseDto>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_index", request.index);
                    param.Add("@p_limit", request.limit);
                    param.Add("@p_consult_id", request.consult_id);

                    response.Data = (List<DiagnosticoListResponseDto>)await con.QueryAsync<DiagnosticoListResponseDto>(Helpers.SP_LIST_DIAGNOSTICOS, param, commandType: CommandType.StoredProcedure);
                }

                response.IsSuccess = true;
                response.Message = response.Data.Count > 0 ? Message.QUERY : Message.QUERY_EMPTY;
                response.Total = response.Data.Count > 0 ? response.Data[0].totalRecords : 0;

            }
            catch (Exception ex)
            {
                response.MessageException = ex.Message;
            }

            return response;
        }
    }
}
