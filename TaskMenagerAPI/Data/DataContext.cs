using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ToDo> ToDoes { get; set; }
        public DbSet<User> Users { get ; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    
                    UserName = "Test",

                },
                new User
                {
                   
                    UserName = "test2"
                }) ;

            modelBuilder.Entity<ToDo>().HasData(
                new ToDo
                {
                    Id = 1,
                    UserId ="2",
                    Title = "Test",
                    Description = "Test",
                    Status = Status.Success,
                    DueDate = new DateTime(2022,12,12)
                },
                new ToDo
                {
                    Id = 2,
                    UserId = "2",
                    Title = "Test2",
                    Description = "Test2",
                    Status = Status.Blocked,
                    DueDate = new DateTime(2024,01,01)
                }
                );


            modelBuilder.Entity<ToDo>()
                .HasOne(p => p.User)
                .WithMany(c => c.Todoes)
                .HasForeignKey(c => c.UserId);
                

        }

    }
}
