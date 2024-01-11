using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Data
{
    public class DataContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ToDo> ToDoes { get; set; }
        public DbSet<UserToDo> UserToDoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

           

           modelBuilder.Entity<UserToDo>() 
                .HasKey(ut => new {ut.UserId, ut.ToDoId});
            modelBuilder.Entity<UserToDo>()
                .HasOne(u =>  u.User)
                .WithMany(ut => ut.UserToDoes)
                .HasForeignKey(u => u.UserId).
                OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<UserToDo>()
                .HasOne(t => t.ToDo)
                .WithMany(ut => ut.UserToDoes)
                .HasForeignKey(t => t.ToDoId).
                OnDelete(DeleteBehavior.Cascade);

        }  
    }
}