using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
    }      
}
