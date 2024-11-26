using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Products;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Products;
using SIG_VETERINARIA.Utilities;
using System.Data;

namespace SIG_VETERINARIA.Repository.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }

        public async Task<ResultDto<int>> CreateProduct(ProductCreateRequestDto request)
        {
            var response = new ResultDto<int>();    

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_id", request.id);
                    param.Add("@p_name", request.name);
                    param.Add("@p_cost", request.cost);
                    param.Add("@p_price", request.price);
                    param.Add("@p_stock", request.stock);
                    param.Add("@p_proveedor", request.proveedor);
                    param.Add("@p_status_product", request.status_product);
                    param.Add("@p_category_id", request.category_id);
                    param.Add("@p_photo", request.uri_photo);
                    param.Add("@p_public_id", request.public_id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_PRODUCTS, param, commandType: CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteProduct(DeleteDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_id", request.id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETE_PRODUCT, param, commandType: CommandType.StoredProcedure))
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

        public async Task<ResultDto<ProductListResponseDto>> GetProductDetail(DeleteDto request)
        {
            var response = new ResultDto<ProductListResponseDto>();
            try
            {
                var param = new DynamicParameters();
                param.Add("@p_id", request.id);

                using (var con = new SqlConnection(_connectionString))
                {
                    var query = await con.QueryAsync<ProductListResponseDto>(Helpers.SP_DETAIL_PRODUCT, param, commandType: CommandType.StoredProcedure);
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

        public async Task<ResultDto<ProductListResponseDto>> GetProducts(ProductListRequestDto request)
        {
            var response = new ResultDto<ProductListResponseDto>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@p_index", request.index);
                    param.Add("@p_limit", request.limit);

                    response.Data = (List<ProductListResponseDto>)await con.QueryAsync<ProductListResponseDto>(Helpers.SP_LIST_PRODUCTS, param, commandType: CommandType.StoredProcedure);
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
