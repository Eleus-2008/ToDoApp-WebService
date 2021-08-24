using Core.Entities;
using Core.Entities.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Configurations
{
    public class TodolistItemConfiguration : IEntityTypeConfiguration<TodolistItem>
    {
        public void Configure(EntityTypeBuilder<TodolistItem> builder)
        {
            builder
                .OwnsOne(e => e.RepeatingConditions, repeatingConditions =>
                {
                    repeatingConditions
                        .Ignore(e => e.RepeatingDaysOfWeek)
                        .Property(e => e.Type)
                        .HasConversion(new EnumToStringConverter<TypeOfRepeatTimeSpan>())
                        .HasColumnType("TEXT");
                })
                .ToTable("TodolistItems");
        }
    }
}