using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.DTO
{
    public class UserWithTaskDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public ICollection<ToDo> Todoes { get; set; }
    }
}
