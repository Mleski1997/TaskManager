using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Interfaces;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        

        public AccountRepository(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;

            
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
           return await _userManager.CheckPasswordAsync(checkUser, loginDto.Password);
        }

        public async Task<bool> RegisterUser (RegisterUserDto registerDto)
        {
            var User = new User()
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                UserIsActive = true
                
                
            };

            var result = await _userManager.CreateAsync(User, registerDto.Password);


            return result.Succeeded;
      
        }

      
    }
}
