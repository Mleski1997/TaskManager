using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskMenagerAPI.Configuration;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Interfaces;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtConfig _jwtConfig;

        public AccountRepository(UserManager<IdentityUser> userManager, IConfiguration configuration, IOptions<JwtConfig> jwtConfig)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfig = jwtConfig.Value;
        }

        public string GenerateJetToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            var tokenDescripter = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),

                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescripter);
            var jwtTokenString = jwtTokenHandler.WriteToken(token);

            return jwtTokenString;
        }

        public async Task<IdentityUser> RegisterUser (RegisterUserDto registerDto)
        {
            var user = new IdentityUser()
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
          

           if (result.Succeeded)
            {
                
                return user;
            }
           else
            {
                return null;
            }
          
            
        }

      
    }
}
