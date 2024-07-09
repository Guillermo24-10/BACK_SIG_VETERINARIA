using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.User;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Auth;
using SIG_VETERINARIA.DTOs.DTOs.User;
using SIG_VETERINARIA.Utilities;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SIG_VETERINARIA.Repository.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private string _connectionString = "";
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SIG_VETERINARIA")!;
        }

        public async Task<ResultDto<int>> Create(UserCreateRequestDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_username", request.username);
                    parameters.Add("@p_password", request.password);
                    parameters.Add("@p_role_id", request.role_id);
                    parameters.Add("@p_create_date", request.create_date);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_CREATE_USER, parameters, commandType: CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> Delete(DeleteDto request)
        {
            var response = new ResultDto<int>();

            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    using (var lector = await con.ExecuteReaderAsync(Helpers.SP_DELETE_USER, parameters, commandType: CommandType.StoredProcedure))
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

        public TokenResponseDto GenerateToken(UserDetailResponseDto request)
        {
            var key = _configuration.GetSection("JWTSettings:Key").Value;
            var keyBytes = Encoding.ASCII.GetBytes(key!);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.id.ToString()));
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.username!));
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.role_id.ToString()));

            var credentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWTSettings:Expires"]!)),
                SigningCredentials = credentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(tokenConfig);

            return new TokenResponseDto { Token = token };
        }

        public async Task<ResultDto<UserListResponseDTO>> GetAll(UserListRequestDto request)
        {
            var response = new ResultDto<UserListResponseDTO>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_indice", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var con = new SqlConnection(_connectionString))
                {
                    response.Data = (List<UserListResponseDTO>)await con.QueryAsync<UserListResponseDTO>(Helpers.SP_LIST_USERS, parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
            var user = await ValidateUser(request);
            var token = GenerateToken(user);

            return new AuthResponseDto { IsSuccess = true, User = user, Token = token.Token };
        }

        private async Task<UserDetailResponseDto> GetUserByUsername(string username)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@p_username", username);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = await con.QueryAsync<UserDetailResponseDto>(Helpers.SP_GET_USER_BY_USERNAME, parameters, commandType: CommandType.StoredProcedure);

                if (query.Any())
                {
                    return query.First();
                }
                else
                {
                    throw new Exception("Usuario o contraseña incorrectos");
                }
            }
        }

        private async Task<UserDetailResponseDto> ValidateUser(LoginRequestDto request)
        {
            UserDetailResponseDto user = await GetUserByUsername((request.username!));
            if (user.password == request.password)
            {
                return user;
            }
            throw new Exception("Usuario o contraseña incorrectos");
        }
    }
}
