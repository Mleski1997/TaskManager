using Microsoft.AspNetCore.Identity;

namespace TaskMenagerAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public ICollection<ToDo> Todoes { get; set; } 

    }
}
