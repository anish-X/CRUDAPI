using CRUDAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using CRUDAPI.Model;
using CRUDAPI.DTOs;

namespace CRUDAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
       
        [HttpGet]  
        public async Task<IActionResult> GetAll()
        {
            var user =  await _userService.GetAllAsync();
            return Ok(user);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _userService.GetByUsernameAsync(username);
            if (user == null) { return NotFound(); }
            return Ok(user);
        }

        [HttpPost]  
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            await _userService.CreateUserAsync(userDto);
            return Ok(userDto);
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> Update(string username, UserDto userDto)
        {
            var existingUser = await _userService.GetByUsernameAsync(username);
            if(existingUser == null) { return NotFound(); } 

            existingUser.Name = userDto.Name;
            existingUser.Email = userDto.Email;
            existingUser.Password = userDto.Password;

            await _userService.UpdateUserAsync(username, userDto);
            return Ok(existingUser);
            
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            var user = await _userService.DeleteUserAsync(username);
            return Ok(user);
        }
    }
}
