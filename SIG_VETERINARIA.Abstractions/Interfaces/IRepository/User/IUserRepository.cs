﻿using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Auth;
using SIG_VETERINARIA.DTOs.DTOs.User;

namespace SIG_VETERINARIA.Abstractions.Interfaces.IRepository.User
{
    public interface IUserRepository
    {
        public Task<ResultDto<UserListResponseDTO>> GetAll(UserListRequestDto request);
        public Task<ResultDto<int>> Create(UserCreateRequestDto request);
        public Task<ResultDto<int>> Delete(DeleteDto request);
        public TokenResponseDto GenerateToken(UserDetailResponseDto request);
        public Task<AuthResponseDto> Login(LoginRequestDto request);
    }
}
