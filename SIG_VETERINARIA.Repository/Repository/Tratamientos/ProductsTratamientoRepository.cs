using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Tratamiento;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Tratamientos;
using SIG_VETERINARIA.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG_VETERINARIA.Repository.Repository.Tratamientos
{
    public class ProductsTratamientoRepository : IProductsTratamientoRepository
    {
        private string _connectionString;

        public ProductsTratamientoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }

        public async Task<ResultDto<int>> CreateProductTratamiento(List<ProductsTratamientoCreateRequestDto> request)
        {
            var response = new ResultDto<int>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    foreach (var item in request)
                    {
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@p_id", item.id);
                        param.Add("@p_tratamiento_id", item.tratamiento_id);
                        param.Add("@p_product_id", item.product_id);

                        using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_PRODUCTS_TRATAMIENTOS, param, commandType: CommandType.StoredProcedure))
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
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.MessageException = ex.Message;
            }

            return response;
        }

        public async Task<ResultDto<int>> DeleteProductTratamiento(DeleteDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@p_id", request.id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETE_PRODUCTO_TRATAMIENTO, param, commandType: CommandType.StoredProcedure))
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

        public async Task<ResultDto<ProductsTratamientoListResponseDto>> GetProductsTratamiento(ProductsTratamientoListRequestDTO request)
        {
            var response = new ResultDto<ProductsTratamientoListResponseDto>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@p_index", request.index);
                    param.Add("@p_limit", request.limit);
                    param.Add("@p_tratamiento_id", request.tratamiento_id);

                    response.Data = (List<ProductsTratamientoListResponseDto>)await con.QueryAsync<ProductsTratamientoListResponseDto>(Helpers.SP_LIST_PRODUCTS_TRATAMIENTOS, param, commandType: CommandType.StoredProcedure);
                    response.IsSuccess = true;
                    response.Message = response.Data.Count > 0 ? Message.QUERY : Message.QUERY_EMPTY;                   
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
