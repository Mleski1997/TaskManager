using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.VisualBasic;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.DTO;
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

        public async Task <bool> CreateToDo(ToDo toDo)
        {
           
            _context.Add(toDo);

           
            return await Save();
        }

        public async Task<ICollection<ToDo>> GetAllToDo()
        {

            return await _context.ToDoes.ToListAsync();
            
        }

        public async Task<ICollection<ToDo>> GetAllToDoFromUser(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return null; // lub pusty IEnumerable w zależności od wymagań
            }

            var todoes = await _context.ToDoes
                .Where(t => t.UserToDoes.Any(ut => ut.UserId == user.Id))
        .ToListAsync();

            return (ICollection<ToDo>)todoes.Select(todo => new ToDoDTO
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status,
                DueDate = todo.DueDate,
               
            }).ToList();
        }

   
        public async Task<ICollection<ToDo>> GetAllToDoByDate()
        {

            return await _context.ToDoes.OrderBy(c => c.DueDate).ToListAsync();

        }
        public async Task<ICollection<ToDo>> GetAllToDoByStatus()
        {

            return await _context.ToDoes.OrderBy(c => c.Status).ToListAsync();

        }

        public async Task<ICollection<ToDo>> GetAllFilterByTitle(string title)
        {
            return await _context.ToDoes.Where(c => c.Title.ToLower() == title.ToLower()).ToListAsync();
        }
        public async Task<ICollection<ToDo>> GetAllFilterByStatus(Status status)
        {
            return await _context.ToDoes.Where(c => c.Status == status).ToListAsync();
        }

        public async Task <ToDo> GetTodo(int todoId)
        {
            return await _context.ToDoes.Include(t => t.UserToDoes).FirstOrDefaultAsync(t => t.Id == todoId);
        }
    
        public async Task <bool> UpdateToDo(int todoId, [FromBody] ToDoEditDTO updatedToDo)
        {
            var editToDo = await _context.ToDoes.FirstOrDefaultAsync(t => t.Id == todoId);
            if (editToDo == null)
            {
                return false;
            }
       
            
                editToDo.Status = (Status)updatedToDo.Status;
                editToDo.Title = updatedToDo.Title;
                editToDo.Description = updatedToDo.Description;
                editToDo.DueDate = updatedToDo.DueDate;

                 return await Save();
        }

        public async Task <bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> DeleteToDo(ToDo toDo)
        {
            _context.Remove(toDo);
            return await Save();
        }

       
    }
}
