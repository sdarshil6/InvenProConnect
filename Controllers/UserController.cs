using InvenProConnect.DTOs;
using InvenProConnect.Managers.Interfaces;
using InvenProConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace InvenProConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("get_all_users")]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                List<GetAllUsersDto> dtoList = await _userManager.GetAllUsers();
                if (dtoList != null)
                {
                    return Ok(dtoList);
                }
                return NotFound("Users not found");
            }
            catch (Exception ex)
            {
                Log.Error("Error occured inside class UserController.cs in GetAllUsers() : " + ex.Message, ex);
                throw;
            }
        }

        [HttpGet("get_user_by_id/{id:long}")]
        public async Task<ActionResult<GetUserDto>> GetUserById([FromRoute]long id)
        {
            try
            {
                GetUserDto userDto = await _userManager.GetUserById(id);
                if (userDto == null)
                {
                    return NotFound("No user found");
                }
                return userDto;
            }
            catch (Exception ex)
            {
                Log.Error("Error occured inside class UserController.cs in GetUserById() : " + ex.Message, ex);
                throw;
            }
        }

        [HttpPost("add_user")]
        public async Task<ActionResult> AddUser([FromBody] InsertUserDto insertUserDto)
        {
            try
            {
                if (insertUserDto == null)
                {
                    return BadRequest("Invalid user object. Please try again.");
                }
                await _userManager.InsertUser(insertUserDto);
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                Log.Error("Error occured inside class UserController.cs in AddUser() : " + ex.Message, ex);
                throw;
            }
        }

        [HttpDelete("delete_user")]
        public async Task<ActionResult> DeleteUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Invalid user object. Please try again.");
                }
                await _userManager.DeleteUser(user);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                Log.Error("Error occured inside class UserController.cs in DeleteUser() : " + ex.Message, ex);
                throw;
            }
        }

        [HttpPut("update_user/{id:long}")]
        public async Task<ActionResult> UpdateUser([FromRoute] long id, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                if (updateUserDto == null)
                {
                    return BadRequest("Invalid user object. Please try again.");
                }
                await _userManager.UpdateUser(id, updateUserDto);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                Log.Error("Error occured inside class UserController.cs in UpdateUser() : " + ex.Message, ex);
                throw;
            }
        }
    }
}
