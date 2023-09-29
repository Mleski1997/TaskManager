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
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);







            modelBuilder.Entity<ToDo>()
                .HasOne(p => p.User)
                .WithMany(c => c.Todoes)
                .HasForeignKey(c => c.UserId);


        }

     
    }
}