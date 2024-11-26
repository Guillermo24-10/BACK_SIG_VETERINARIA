using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Tratamiento;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;
using SIG_VETERINARIA.Utilities;
using System.Data;

namespace SIG_VETERINARIA.Repository.Repository.Tratamientos
{
    public class TratamientoRepository : ITratamientosRepository
    {
        private readonly string _connectionString;

        public TratamientoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }

        public async Task<ResultDto<int>> CreateTratamiento(TratamientoCreateRequestDto request)
        {
            var response = new ResultDto<int>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@p_id", request.id);
                    param.Add("@p_detalle", request.detalle);
                    param.Add("@p_diagnostico_id", request.diagnostico_id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_TRATAMIENTO, param, commandType: CommandType.StoredProcedure))
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
                response.IsSuccess = false;
                response.MessageException = ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<int>> DeleteTratamiento(DeleteDto request)
        {
            var response = new ResultDto<int>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@p_id", request.id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETE_TRATAMIENTO,param,commandType:CommandType.StoredProcedure))
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
                response.IsSuccess = false;
                response.MessageException = ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<TratamientoListResponseDto>> ListTratamientos(TratamientoListRequestDto request)
        {
            var response = new ResultDto<TratamientoListResponseDto>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_index", request.index);
                    parameters.Add("@p_limit", request.limit);
                    parameters.Add("@p_diagnostico_id", request.diagnostico_id);

                    response.Data = (List<TratamientoListResponseDto>)await con.QueryAsync<TratamientoListResponseDto>(Helpers.SP_LIST_TRATAMIENTOS, parameters, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = response.Data.Count >= 0 ? true : false;
                    response.Message = response.Data.Count > 0 ? Message.QUERY : Message.QUERY_EMPTY;
                    response.Total = response.Data.Count > 0 ? response.Data.First().totalRecords : 0;
                }
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
