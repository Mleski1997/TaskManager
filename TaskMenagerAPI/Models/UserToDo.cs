namespace TaskMenagerAPI.Models
{
    public class UserToDo
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int ToDoId { get; set; }
        public ToDo ToDo { get; set; }
      
    }
}
