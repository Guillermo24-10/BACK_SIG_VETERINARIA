using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Clients;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Clients;
using SIG_VETERINARIA.Utilities;
using System.Data;

namespace SIG_VETERINARIA.Repository.Repository.Clients
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;
        public ClientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }

        public async Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_name", request.name);
                    parameters.Add("@p_lastnames", request.lastnames);
                    parameters.Add("@p_photo", request.uri_photo);
                    parameters.Add("@p_document_number", request.document_number);
                    parameters.Add("@p_document_type", request.document_type);
                    parameters.Add("@p_phone", request.phone);
                    parameters.Add("@p_address", request.address);
                    parameters.Add("@p_city", request.city);
                    parameters.Add("@p_email", request.email);
                    parameters.Add("@p_public_id", request.public_id);
                    parameters.Add("@p_signature", request.signature);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_CLIENTS, parameters, commandType: CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteClient(DeleteDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETE_CLIENT, parameters, commandType: CommandType.StoredProcedure))
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

        public async Task<ResultDto<ClientDetailResponseDto>> GetClientDetail(int id)
        {
            var response = new ResultDto<ClientDetailResponseDto>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", id);

                    var query = await con.QueryAsync<ClientDetailResponseDto>(Helpers.SP_GET_CLIENT, parameters, commandType: CommandType.StoredProcedure);
                    response.Item = query.FirstOrDefault();
                    response.IsSuccess = true;
                    response.Message = query.Any() ? Message.QUERY : Message.QUERY_EMPTY;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.MessageException = ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request)
        {
            var response = new ResultDto<ClientListResponseDto>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_indice", request.index);
                    parameters.Add("@p_limit", request.limit);

                    response.Data = (List<ClientListResponseDto>)await con.QueryAsync<ClientListResponseDto>(Helpers.SP_LIST_CLIENTS, parameters, commandType: CommandType.StoredProcedure);
                }
                response.IsSuccess = true;
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
