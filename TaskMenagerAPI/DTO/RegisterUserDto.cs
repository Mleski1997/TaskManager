using Microsoft.Build.Framework;

namespace TaskMenagerAPI.DTO
{
    public class RegisterUserDto
    {

        [Required]
        public string  UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }    
        
    }
}
