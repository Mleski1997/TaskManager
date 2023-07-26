using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace TaskMenagerAPI.Models
{
    public  class User : IdentityUser
    {
        public bool UserIsActive { get; set; }
       
        public ICollection<ToDo> Todoes { get; set; }


    }
}
