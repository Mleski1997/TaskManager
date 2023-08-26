using Microsoft.AspNetCore.Identity;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Interfaces
{
    public interface IAccountRepository
    {
        string GenerateJwtToken(User user);
        Task<bool> RegisterUser (RegisterUserDto registerDto);
        Task<bool> LoginUser (LoginUserDTO loginDto);
      
    }
}
