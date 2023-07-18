using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        User GetUser(int userId);
        ICollection<ToDo> GetTodoesFromTodo(int userId);

        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
