using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Interfaces;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }

        public string GenerateJetToken(LoginUserDTO loginDto)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,loginDto.UserName)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }

        public async Task<bool> LoginUser(LoginUserDTO loginDto)
        { 
            
             var checkUser = await  _userManager.FindByNameAsync(loginDto.UserName);

            if (checkUser is null)
            {
                return false;
            }
           var result = await  _signInManager.CheckPasswordSignInAsync(checkUser, loginDto.Password, false);
            if(!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RegisterUser (RegisterUserDto registerDto)
        {
            var User = new User()
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                IsActive = true


            };

            var result = await _userManager.CreateAsync(User, registerDto.Password);


            return result.Succeeded;
      
        }

       
    }
}
