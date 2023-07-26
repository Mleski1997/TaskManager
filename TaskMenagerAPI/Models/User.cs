using Microsoft.AspNetCore.Identity;


namespace TaskMenagerAPI.Models
{
    public class User : IdentityUser
    {
      
      
        public bool UserIsActive { get; set; }

        public ICollection<ToDo> Todoes { get; set; }


    }
}
