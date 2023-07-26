using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskMenagerAPI.Data;
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

        public bool CreateUser(User user)
        {
            _context.Add(user);
           

            return Save();


        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);

            return Save();
        }

        public ICollection<ToDo> GetTodoesFromTodo(int userId)
        {
            return _context.ToDoes.Where(r => r.Id == userId).ToList();
        }

        public User GetUser(int userId)
        {
            return _context.Users.Where(u => userId == userId).Include(e => e.Todoes).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
