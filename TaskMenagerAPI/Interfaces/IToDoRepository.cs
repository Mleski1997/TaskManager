using TaskMenagerAPI.Data;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Interfaces
{
    public interface IToDoRepository
    {
        ICollection<ToDo> GetAllToDo();
        ICollection<ToDo> GetAllToDoByDate();
        ICollection<ToDo> GetAllToDoByStatus();
        ICollection<ToDo> GetAllFilterByTitle(string title);
        ICollection<ToDo> GetAllFilterByStatus(Status status);
        ToDo GetTodo(int todoId);
        bool CreateToDo (ToDo toDo);
        bool UpdateToDo (ToDo toDo);
        bool DeleteToDo(ToDo toDo);
        bool Save();
    }
}
