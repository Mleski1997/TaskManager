using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Interfaces
{
    public interface IUserRepository
    {
        Task <ICollection<User>> GetUsers();

        Task <User> GetUser(string userId);
        Task <ICollection<ToDo>> GetTodoesFromTodo(string userId);



        Task <bool> DeleteUser(User user);
        Task <bool> Save();
        Task <bool> UpdateUser(string userId, UserDTO updatedUser);
        Task<bool> UpdateActive(string userId, UserActiveDTO activeUser);
    }
}