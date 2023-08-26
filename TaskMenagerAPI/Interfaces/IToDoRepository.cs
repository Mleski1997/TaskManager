using Microsoft.AspNetCore.Mvc;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Interfaces
{
    public interface IToDoRepository
    {
        Task <ICollection<ToDo>> GetAllToDo();
        Task <ICollection<ToDo>> GetAllToDoFromUser(string userId);
        Task<ICollection<ToDo>> GetAllToDoByDate();
        Task<ICollection<ToDo>> GetAllToDoByStatus();
        Task<ICollection<ToDo>> GetAllFilterByTitle(string title);
        Task<ICollection<ToDo>> GetAllFilterByStatus(Status status);
        Task <ToDo> GetTodo(int todoId);
        Task <bool> CreateToDo (ToDo toDo);
        Task <bool> UpdateToDo (int todoId, [FromBody] ToDoDTO updatedToDo);
        Task <bool> DeleteToDo(ToDo toDo);
        Task<bool> Save();
        
    }
}
