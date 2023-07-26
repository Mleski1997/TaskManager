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

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }
        public ICollection<ToDo> GetTodoesFromTodo(int userId)
        {
            return _context.ToDoes.Where(r => r.Id == userId).ToList();
        }





        public bool DeleteUser(User user)
        {
            _context.Remove(user);

            return Save();
        }


        public bool UpdateUser(string userId, UserDTO updatedUser)
        {
           var exist = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (exist == null)
            {
                return false;
            }

            exist.UserName = updatedUser.UserName;
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
