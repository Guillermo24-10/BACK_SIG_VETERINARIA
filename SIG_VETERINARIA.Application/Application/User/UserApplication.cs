using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.User;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.User;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.Auth;
using SIG_VETERINARIA.DTOs.DTOs.User;

namespace SIG_VETERINARIA.Application.Application.User
{
    public class UserApplication : IUserApplication
    {
        private IUserService _userService;

        public UserApplication(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ResultDto<int>> Create(UserCreateRequestDto request)
        {
            return await _userService.Create(request);
        }

        public async Task<ResultDto<int>> Delete(DeleteDto request)
        {
            return await _userService.Delete(request);
        }

        public async Task<ResultDto<UserListResponseDTO>> GetAll(UserListRequestDto request)
        {
            return await _userService.GetAll(request);
        }

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
            return await _userService.Login(request);
        }
    }
}
