using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Interfaces
{
    public interface IUserIsLogged
    {
        Task<User> GetUserLogged(string loggedUser);

    }
}
