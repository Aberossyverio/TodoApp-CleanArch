namespace TodoApp.UseCases.DTOs;

  public class TodoItemDTO
  {
      public int Id { get; set; }
      public required string Title { get; set; }
      public required string Description { get; set; }
      public bool IsCompleted { get; set; }
      public DateTime CreatedDate { get; set; }
  }
