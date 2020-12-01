using Core.Entities;
using Core.Entities.Enumerations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
                .OwnsOne(e => e.RepeatingConditions, repeatingConditions =>
                {
                    repeatingConditions
                        .Ignore(e => e.RepeatingDaysOfWeek)
                        .Property(e => e.Type)
                        .HasConversion(new EnumToStringConverter<TypeOfRepeatTimeSpan>())
                        .HasColumnType("TEXT");
                })
                .ToTable("Tasks");

            modelBuilder.Entity<ToDoList>().ToTable("ToDoLists");

            base.OnModelCreating(modelBuilder);
        }
    }
}