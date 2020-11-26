using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SqlServerContext : IdentityDbContext
    {
        public DbSet<ToDoList> ToDoLists;
        public DbSet<Task> Tasks;
        
        public SqlServerContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .OwnsOne(e => e.RepeatingConditions)
                .ToTable("Tasks");

            modelBuilder.Entity<ToDoList>().ToTable("ToDoLists");
        }
    }
}