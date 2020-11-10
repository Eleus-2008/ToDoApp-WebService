using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoApp.Model;

namespace Data
{
    public class SqlServerContext : DbContext
    {
        public DbSet<User> Users;
        public DbSet<ToDoList> ToDoLists;
        public DbSet<Task> Tasks;
        
        public SqlServerContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=todoappservice;Trusted_Connection=True;");
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