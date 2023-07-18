using TaskMenagerAPI.Data;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI
{
    public class TaskSeeder
    {
        private readonly DataContext _dbContext;

        public TaskSeeder(DataContext dbContext)
        {
           _dbContext = dbContext;
        }

        public void Seed()
        {
            if(!_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
            }

        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {

                    FirstName = "Michal",
                    LastName = "Leski",
                    Todoes = new List<ToDo>()
                    {
                        new ToDo()
                        {

                            Title = "Zadanie1",
                            Description = "Nauka",
                            Status = "During",

                        },

                        new ToDo()
                        {

                            Title = "Zadanie2",
                            Description = "Zawody",
                            Status = " sfsfsa",

                        }
                    }
                },
                new User()
                {

                    FirstName = "Elo",
                    LastName = " Kocie",
                    Todoes = new List<ToDo>()
                    {
                        new ToDo()
                        {

                            Title = "koniec",
                            Description = "Baletow",
                            Status = "ok"
                        }
                    },



                }
            };
            return users;
        }
       
    }
}
