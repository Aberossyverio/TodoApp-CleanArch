namespace TodoApp.Web.TodoItems.CreateTodoItem;

  public class CreateTodoItemResponse
  {
      public int Id { get; set; }
      public required string Title { get; set; }
      public required string Description { get; set; }
      public bool IsCompleted { get; set; }
      public DateTime CreatedDate { get; set; }
  }
