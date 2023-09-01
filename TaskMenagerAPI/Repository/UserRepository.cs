using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Interfaces;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public  async Task <ICollection<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task <User> GetUser(string userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
        public async Task <ICollection<ToDo>> GetTodoesFromTodo(string userId)
        {
            return await _context.ToDoes.Where(r => r.UserId == userId).ToListAsync();
        }

  
        public async Task<bool> DeleteUser(User user)
        {
            _context.Remove(user);

            return await Save();
        }


        public async Task<bool> UpdateUser(string userId, UserDTO updatedUser)
        {
            var exist = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (exist == null)
            {
                return false;
            }

            exist.NormalizedUserName = updatedUser.UserName;
            exist.IsActive = updatedUser.IsActive;
            return  await Save();
        }

        public async Task<bool>UpdateActive(string userId, UserActiveDTO activeUser)
        {
            var exist = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (exist == null)
            {
                return false;
            }
            exist.IsActive = activeUser.IsActive;
            return await Save();
        }

        public async Task <bool> Save()
        {
            var saved = _context.SaveChangesAsync();
            return await saved > 0 ? true : false;
        }

 
    }
}