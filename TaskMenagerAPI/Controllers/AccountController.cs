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
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TaskMenagerAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase

 
    {
        private readonly UserManager<IdentityUser> _userManager;
       
        private readonly IAccountRepository _accountRepository;
        
        private readonly DataContext _context;

        public AccountController(UserManager<IdentityUser> userManager,  IAccountRepository accountRepository,  DataContext context
            )
        {
            _userManager = userManager;
            _accountRepository = accountRepository;
            _context = context;
        }

      

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto registerDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (registerDto == null)
            {
                return BadRequest(ModelState);              
            }

           
            var user = await  _userManager.FindByNameAsync(registerDto.UserName);

            if (user != null) {
                ModelState.AddModelError("", "Username already exists");
                return BadRequest(ModelState);
            }           
           if (!await _accountRepository.RegisterUser(registerDto))
            {
                return BadRequest("Something went wrong");
                
            }
            return Ok("Created");
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDTO loginDto)

        {

            
          /*  var userLogged = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);
            

            if (!userLogged.IsActive)
            {
                return BadRequest("User is disabled");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } */

            var result = await _accountRepository.LoginUser(loginDto);
            if (result != true)
            {
                return BadRequest();
            }

            var token= _accountRepository.GenerateJetToken(loginDto);

          
            return Ok(new { token });


        }

  
    }
}

    
