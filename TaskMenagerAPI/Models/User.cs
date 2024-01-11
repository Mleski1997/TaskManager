using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace TaskMenagerAPI.Models
{
    public  class User : IdentityUser
    {
        
        public bool IsActive { get; set; }
        public ICollection<ToDo> Todoes { get; set; }
        public ICollection<UserToDo> UserToDoes { get; set; }
    }
}
