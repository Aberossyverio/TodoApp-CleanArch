using System;

namespace TodoApp.Core.TodoItem.Models;

  public class Todo
  {
      public int Id { get; set; }
      public string Title { get; set; } = string.Empty;
      public string Description { get; set; } = string.Empty;
      public bool IsCompleted { get; set; }
      public DateTime CreatedDate { get; set; }
      
      // Constructor
      public Todo(int id, string title, string description, bool isCompleted, DateTime createdDate)
      {
          Id = id;
          Title = title;
          Description = description;
          IsCompleted = isCompleted;
          CreatedDate = createdDate;
      }

      // Default constructor for deserialization
      public Todo() { }
  }
