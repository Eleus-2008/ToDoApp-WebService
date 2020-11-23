using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SqlServerContext : DbContext
    {
        public DbSet<User> Users;
        public DbSet<ToDoList> ToDoLists;
        public DbSet<Task> Tasks;
        
        public SqlServerContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            
            modelBuilder.Entity<Task>()
                .OwnsOne(e => e.RepeatingConditions)
                .ToTable("Tasks");

            modelBuilder.Entity<ToDoList>().ToTable("ToDoLists");
        }
    }
}