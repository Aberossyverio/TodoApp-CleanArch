namespace TodoApp.Web.TodoItems.CreateTodoItem;

  public class CreateTodoItemRequest
  {
      public required string Title { get; set; }
      public required string Description { get; set; }
      public DateTime CreatedDate { get; set; }
  }
