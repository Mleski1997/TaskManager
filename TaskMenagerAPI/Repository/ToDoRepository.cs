using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.Interfaces;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataContext _context;

        public ToDoRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateToDo(ToDo toDo)
        {
            _context.Add(toDo);
            return Save();
        }

        public ICollection<ToDo> GetAllToDo()
        {

            return _context.ToDoes.ToList();
            
        }
        public ICollection<ToDo> GetAllToDoByDate()
        {

            return _context.ToDoes.OrderBy(c => c.DueDate).ToList();

        }
        public ICollection<ToDo> GetAllToDoByStatus()
        {

            return _context.ToDoes.OrderBy(c => c.Status).ToList();

        }

        public ICollection<ToDo> GetAllFilterByTitle(string title)
        {
            return _context.ToDoes.Where(c => c.Title.ToLower() == title.ToLower()).ToList();
        }
        public ICollection<ToDo> GetAllFilterByStatus(Status status)
        {
            return _context.ToDoes.Where(c => c.Status == status).ToList();
        }

        public ToDo GetTodo(int todoId)
        {
            return _context.ToDoes.Include(t => t.User).FirstOrDefault(t => t.Id == todoId);
        }

       
     


    
        public bool UpdateToDo(ToDo toDo)
        {
            _context.Update(toDo);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool DeleteToDo(ToDo toDo)
        {
            _context.Remove(toDo);
            return Save();
        }
    }
}
