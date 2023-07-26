using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.Models;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TaskMenagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IAccountRepository _accountRepository;

        public AccountController(UserManager<IdentityUser> userManager, IConfiguration configuration, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _accountRepository = accountRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerDto)
        {
           if (await _accountRepository.RegisterUser(registerDto))
            {
                return Ok("Created");
            }
           return BadRequest("Something went wrong");
        }

        [HttpPost("login")]
        public async Task <IActionResult> LoginUser([FromBody] LoginUserDTO loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _accountRepository.LoginUser(loginDto);

            if(result == true)
            {
                var tokenString = _accountRepository.GenerateJetToken(loginDto);
                return Ok(tokenString);
            }
            return BadRequest();

        } 




       
        }


    }

    
