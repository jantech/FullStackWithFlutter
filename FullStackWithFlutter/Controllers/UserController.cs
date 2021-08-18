using FullStackWithFlutter.Core.ViewModels;
using FullStackWithFlutter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackWithFlutter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
            var userList = await _userService.GetAllUsers();
            var resp = new ApiResponse { Status = true, Message = "All Users fected successfully", Data = userList };
            return Ok(resp);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(int userId)
        {
            var user = await _userService.GetUserById(userId);

            if (user != null)
            {
                var resp = new ApiResponse { Status = true, Message = "User details fected successfully", Data = user };
                return Ok(resp);
            }
            else
            {
                var resp = new ApiResponse { Status = false, Message = "User details not found!", Data = null };
                return BadRequest(resp);
            }
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(SaveAppUserViewModel userViewModel)
        {
            var userCreated = await _userService.CreateNewUser(userViewModel);

            if (userCreated)
            {
                var resp = new ApiResponse { Status = true, Message = "User created successfully", Data = null };
                return Ok(resp);
            }
            else
            {
                var resp = new ApiResponse { Status = false, Message = "Unable to create user details!", Data = null };
                return BadRequest(resp);
            }
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int userId, SaveAppUserViewModel userViewModel)
        {
            var userCreated = await _userService.UpdateUser(userId, userViewModel);

            if (userCreated)
            {
                var resp = new ApiResponse { Status = true, Message = "User details updated successfully", Data = null };
                return Ok(resp);
            }
            else
            {
                var resp = new ApiResponse { Status = false, Message = "Unable to update user details!", Data = null };
                return BadRequest(resp);
            }
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int userId)
        {
            var userCreated = await _userService.DeleteUser(userId);

            if (userCreated)
            {
                var resp = new ApiResponse { Status = true, Message = "User details deleted successfully", Data = null };
                return Ok(resp);
            }
            else
            {
                var resp = new ApiResponse { Status = false, Message = "Unable to delete user details!", Data = null };
                return BadRequest(resp);
            }
        }

    }
}
