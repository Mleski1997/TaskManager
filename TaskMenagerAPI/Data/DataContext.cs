using Microsoft.EntityFrameworkCore;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Data
{
    public class DataContext : DbContext
    {
        

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user1 = new User { Id = 1, FirstName = "Test", LastName ="Test" };
            var user2 = new User { Id = 2, FirstName = "Test2", LastName = "Test2" };

            var todo1 = new ToDo { Id = 1, UserId = 1, Title = "Test", Description = "Test2", Status = "ok" };
            var todo2 = new ToDo { Id = 2, UserId = 2, Title = "Test2", Description= "Test2", Status = "ok" };

            modelBuilder.Entity<User>().HasData(user1, user2);
            modelBuilder.Entity<ToDo>().HasData(todo1, todo2);

            modelBuilder.Entity<User> () 
                .HasMany(p => p.Todoes)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .IsRequired();

        }

    }
}
