using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskMenagerAPI.Data;

namespace TaskMenagerAPI.Models
{
    public class ToDo
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime DueDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }


    }
}