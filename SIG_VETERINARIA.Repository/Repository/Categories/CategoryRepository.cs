using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Categories;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Categories;
using SIG_VETERINARIA.Utilities;
using System.Data;

namespace SIG_VETERINARIA.Repository.Repository.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private string _connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }

        public async Task<ResultDto<int>> CreateCategory(CategoriesCreateRequestDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_id", request.id);
                    param.Add("@p_name", request.name);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_CATEGORY, param, commandType: CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteCategory(DeleteDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_id", request.id);
                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETET_CATEGORY, param, commandType: CommandType.StoredProcedure))
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
                response.MessageException = ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<CategoriesListResponseDto>> GetAll(CategoriesListRequestDto request)
        {
            var response = new ResultDto<CategoriesListResponseDto>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_index", request.index);
                    param.Add("@p_limit", request.limit);

                    response.Data = (List<CategoriesListResponseDto>)await con.QueryAsync<CategoriesListResponseDto>(Helpers.SP_LIST_CATEGORIES, param, commandType: CommandType.StoredProcedure);
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
