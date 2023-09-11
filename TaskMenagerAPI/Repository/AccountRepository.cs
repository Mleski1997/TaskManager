using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public AccountRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,  SignInManager<User> signInManager, IConfiguration configuration, DataContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }



        public async Task<bool> LoginUser(LoginUserDTO loginDto)
        {

            var user  = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user is null)
            {
                return false;
            }

            
            var signInResult = await _signInManager.PasswordSignInAsync(user, loginDto.Password, isPersistent: false, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
             
                return true;
            }
            return false;
            
           // return await _userManager.CheckPasswordAsync(user, loginDto.Password);
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
        public string GenerateJwtToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, "admin")
             
              
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signingCred);

            Console.WriteLine(user.Id);

            var tokenString = tokenHandler.WriteToken(securityToken);
            return tokenString;

            
        }


    }
}
