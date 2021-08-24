using System;
using Core.Entities;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SqlServerContext : IdentityUserContext<User, Guid>
    {
        public DbSet<Todolist> Todolists;
        public DbSet<TodolistItem> TodolistItems;

        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodolistItemConfiguration());
            modelBuilder.ApplyConfiguration(new TodolistConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}