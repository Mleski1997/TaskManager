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
using System.Data;

namespace TaskMenagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountRepository _accountRepository;

        private readonly DataContext _context;
        private readonly IUserIsLogged _userIsLogged;

        public AccountController(UserManager<User> userManager,RoleManager<IdentityRole> roleManager, IAccountRepository accountRepository, DataContext context,  IUserIsLogged userIsLogged
            )
        {
            _userManager = userManager;       
            _roleManager = roleManager;
            _accountRepository = accountRepository;
            _context = context;
            _userIsLogged = userIsLogged;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto registerDto)
        {


            if (!ModelState.IsValid || registerDto == null)
            {
                return BadRequest(ModelState);
            }
     
            var user = await _userManager.FindByNameAsync(registerDto.UserName);

            if (user != null)
            {
                ModelState.AddModelError("", "Username already exists");
                return BadRequest(ModelState);
            }

            var registrationResult = await _accountRepository.RegisterUser(registerDto);
            
            if (!registrationResult)
            {
                return BadRequest("Something went wrong during registration");
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            user = await _userManager.FindByNameAsync(registerDto.UserName);

            var addUserToRoleResult = await _userManager.AddToRoleAsync(user, "User");

            if(!addUserToRoleResult.Succeeded)
            {
                return BadRequest("Failer to add user to role");
            }

            return Ok("User registered successfully");
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDTO loginDto)

        {


            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName );

             if (user == null)
            {
                return BadRequest("Invalid username ot password");
            }
                
          
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(user.IsActive != true)
            {
                return StatusCode(403, "User is disabled");
            }

            var result = await _accountRepository.LoginUser(loginDto);
            if (result == false)
            {
                return BadRequest("Invalid username ot password");
            }

           

            var tokenString = _accountRepository.GenerateJwtToken(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            
         
            
            return Ok(new 
            { 
                tokenString,
                UserId = user.Id,
                Roles = userRoles,
                userIsActive = user.IsActive


            });


        }


    }
}
