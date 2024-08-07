﻿using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.User;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.User;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Auth;
using SIG_VETERINARIA.DTOs.DTOs.User;

namespace SIG_VETERINARIA.Services.Services.User
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultDto<int>> Create(UserCreateRequestDto request)
        {
            return await _userRepository.Create(request);
        }

        public async Task<ResultDto<int>> Delete(DeleteDto request)
        {
            return await _userRepository.Delete(request);
        }

        public async Task<ResultDto<UserListResponseDTO>> GetAll(UserListRequestDto request)
        {
            return await _userRepository.GetAll(request);
        }

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
            return await _userRepository.Login(request);
        }
    }
}
