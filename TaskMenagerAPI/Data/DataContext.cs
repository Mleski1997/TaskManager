using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

            base.OnModelCreating(modelBuilder);
          

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Test",
                },
                new User
                {
                    Id = 2,
                    FirstName = "Test2",
                    LastName = "Test2",
                });

            modelBuilder.Entity<ToDo>().HasData(
                new ToDo
                {
                    Id = 1,
                    UserId = 1,
                    Title = "Test",
                    Description = "Test",
                    Status = Status.Success,
                    DueDate = new DateTime(2022,12,12)
                },
                new ToDo
                {
                    Id = 2,
                    UserId = 2,
                    Title = "Test2",
                    Description = "Test2",
                    Status = Status.Blocked,
                    DueDate = new DateTime(2024,01,01)
                }
                );


            modelBuilder.Entity<User>()
                .HasMany(p => p.Todoes)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
                

        }

    }
}
