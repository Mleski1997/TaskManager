using System.Text.Json.Serialization;

namespace TaskMenagerAPI.DTO
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public string UserId { get; set; }



    }
}
