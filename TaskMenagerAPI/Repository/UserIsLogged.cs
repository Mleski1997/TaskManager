using TaskMenagerAPI.Models;
using Microsoft.AspNetCore.Identity;
using TaskMenagerAPI.Data;
using Microsoft.EntityFrameworkCore;
using TaskMenagerAPI.Controllers;
using TaskMenagerAPI.Interfaces;

namespace TaskMenagerAPI.Repository
{
    public class UserIsLogged : IUserIsLogged
    {
        private readonly DataContext _context;

        public UserIsLogged(DataContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserLogged(string loggedUser)
        {
            
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == loggedUser);
        }

       
    }
}
