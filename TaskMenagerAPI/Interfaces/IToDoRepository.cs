using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Interfaces
{
    public interface IToDoRepository
    {
        ICollection<ToDo> GetAllToDo();
        ToDo GetTodo(int todoId);
        bool CreateToDo (ToDo toDo);
        bool UpdateToDo (ToDo toDo);
        bool DeleteToDo(ToDo toDo);
        bool Save();
    }
}
