﻿using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.User;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.DTOs.User;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserApplication _UserApplication;

        public UserController(IUserApplication userApplication)
        {
            _UserApplication = userApplication;
        }

        [HttpPost]
        [Route("List")]
        public async Task<IActionResult> GetAllUsers([FromBody] UserListRequestDto request)
        {
            try
            {
                var response = await _UserApplication.GetAll(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser(UserCreateRequestDto request)
        {
            try
            {
                var response = await _UserApplication.Create(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteUser(DeleteDto request)
        {
            try
            {
                var response = await _UserApplication.Delete(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
