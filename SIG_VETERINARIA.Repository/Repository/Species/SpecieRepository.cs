using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Specie;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Species;
using SIG_VETERINARIA.Utilities;
using System.Data;

namespace SIG_VETERINARIA.Repository.Repository.Species
{
    public class SpecieRepository : ISpeciesRepository
    {
        private string _connectionString = "";
        public SpecieRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }

        public async Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_name", request.name);
                    parameters.Add("@p_create_date", request.create_date);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_SPECIE, parameters, commandType: CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteSpecie(DeleteDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETE_SPECIE, parameters, commandType: CommandType.StoredProcedure))
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

        public async Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request)
        {
            var response = new ResultDto<SpecieListResponseDto>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@p_indice", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var con = new SqlConnection(_connectionString))
                {
                    response.Data = (List<SpecieListResponseDto>)await con.QueryAsync<SpecieListResponseDto>(Helpers.SP_LIST_SPECIES, parameters, commandType: CommandType.StoredProcedure);
                }
                response.IsSuccess = response.Data.Count >= 0 ? true : false;
                response.Message = response.Data.Count > 0 ? Message.QUERY : Message.QUERY_EMPTY;
                response.Total = response.Data.Count > 0 ? response.Data.First().totalRegisters : 0;
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
