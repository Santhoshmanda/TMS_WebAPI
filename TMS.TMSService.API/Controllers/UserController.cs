using Microsoft.AspNetCore.Mvc;
using TMS.TMSService.Application.DTOs;
using TMS.TMSService.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TMS.TMSService.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetllUsersAsync()
        {
            var users= await _userService.GetllUsersAsync();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUserById(int id)
        {
            var user= await _userService.GetUserByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUserAsync([FromBody] UserDto user)
        {
            var userDto= await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id= userDto.UserId} , userDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(int id, [FromBody] UserDto user)
        {
            if (id != user.UserId)
            {
                return BadRequest("Id is not matching");
            }
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();

        }


  
    }
}

