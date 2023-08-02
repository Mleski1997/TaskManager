using TaskMenagerAPI.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace TaskMenagerAPI.Models
{
    
    public class UserWithPresenttion : User
    {
        private readonly ILogger<UserWithPresenttion> _logger;
        public UserWithPresenttion(ILogger<UserWithPresenttion> logger)
        {
            _logger = logger;
        }

        public void Show(ICollection<User> users)
        {
           foreach (var user in users)
            {
                _logger.LogInformation($"UsernName: {user.UserName}");
            }
            
        }
    }
}
