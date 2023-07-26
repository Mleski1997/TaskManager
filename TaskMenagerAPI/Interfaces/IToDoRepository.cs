using Microsoft.AspNetCore.Mvc;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Interfaces
{
    public interface IToDoRepository
    {
        ICollection<ToDo> GetAllToDo();
        ICollection<ToDo> GetAllToDoFromUser(string userId);
        ICollection<ToDo> GetAllToDoByDate();
        ICollection<ToDo> GetAllToDoByStatus();
        ICollection<ToDo> GetAllFilterByTitle(string title);
        ICollection<ToDo> GetAllFilterByStatus(Status status);
        ToDo GetTodo(int todoId);
        bool CreateToDo (ToDo toDo);
        bool UpdateToDo (int todoId, [FromBody] ToDoDTO updatedToDo);
        bool DeleteToDo(ToDo toDo);
        bool Save();
    }
}
