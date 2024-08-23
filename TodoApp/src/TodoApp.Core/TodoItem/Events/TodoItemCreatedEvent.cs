namespace TodoApp.Core.TodoItem.Events;

  public class TodoItemCreatedEvent
  {
      public int Id { get; }
      public string Title { get; }
      public string Description { get; }
      public DateTime CreatedDate { get; }
      
      // Constructor
      public TodoItemCreatedEvent(int id, string title, string description, DateTime createdDate)
      {
          Id = id;
          Title = title;
          Description = description;
          CreatedDate = createdDate;
      }
  }
