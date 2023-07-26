using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.Models;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TaskMenagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerDto)
        {
            var userExist = await _userManager.FindByEmailAsync(registerDto.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User alreadt exists!" });
            }

            User user = new User
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) 
                 return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }


    }
}
    
