using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ToDo> ToDoes { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


     /*       modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "1",
                    UserName = "Test1",
                    Email = "Michal12op.pl",
                    IsActive = true,

                },
                new User
                {
                    Id = "2",
                    UserName = "test2",
                    Email = "Michal31vp.pl",
                    IsActive = true,


                },
            new User
            {
                Id = "3",
                UserName = "test3",
                Email = "Pioterk@ds.pl",
                IsActive = true,

            },
            new User
            {
                Id = "4",
                UserName = "test4",
                Email = "test@gmail.com",
                IsActive = true,

            }); 

            modelBuilder.Entity<ToDo>().HasData(
                new ToDo
                {
                    Id = 1,
                    UserId = "2",
                    Title = "Test",
                    Description = "Test",
                    Status = Status.Success,
                    DueDate = new DateTime(2022, 12, 12)
                },
                new ToDo
                {
                    Id = 2,
                    UserId = "2",
                    Title = "Test2",
                    Description = "Test2",
                    Status = Status.Blocked,
                    DueDate = new DateTime(2024, 01, 01)
                }
                );  */


            modelBuilder.Entity<ToDo>()
                .HasOne(p => p.User)
                .WithMany(c => c.Todoes)
                .HasForeignKey(c => c.UserId);


        }

    }
}