using Microsoft.AspNetCore.Identity;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityUser> RegisterUser (RegisterUserDto registerDto);
        string GenerateJetToken(IdentityUser user);
    }
}
