using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class TodolistConfiguration : IEntityTypeConfiguration<Todolist>
    {
        public void Configure(EntityTypeBuilder<Todolist> builder)
        {
            builder.ToTable("Todolists");
        }
    }
}