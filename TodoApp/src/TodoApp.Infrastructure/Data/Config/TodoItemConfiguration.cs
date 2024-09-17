using Microsoft.EntityFrameworkCore;
using TodoApp.Core.TodoItem.Models;

namespace TodoApp.Infrastructure.Data.Config;

public class TodoItemConfiguration : IEntityTypeConfiguration<Todo>
{
  public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Todo> builder)
  { 
    builder.ToTable("TodoItems");
    // Primary Key
    builder.HasKey(t => t.Id);

    // Properties
    builder.Property(t => t.Id)
        .IsRequired()
        .ValueGeneratedOnAdd();

    builder.Property(t => t.Title)
        .IsRequired()
        .HasMaxLength(200);

    builder.Property(t => t.Description)
        .IsRequired()
        .HasMaxLength(1000);

    builder.Property(t => t.IsCompleted)
        .IsRequired();

    builder.Property(t => t.CreatedDate)
        .IsRequired();
  }
}
