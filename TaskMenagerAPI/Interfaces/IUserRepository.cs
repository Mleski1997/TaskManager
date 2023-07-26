using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        User GetUser(string userId);
        ICollection<ToDo> GetTodoesFromTodo(int userId);


      
        bool DeleteUser(User user);
        bool Save();
        bool UpdateUser(string userId, UserDTO updatedUser);
    }
}
