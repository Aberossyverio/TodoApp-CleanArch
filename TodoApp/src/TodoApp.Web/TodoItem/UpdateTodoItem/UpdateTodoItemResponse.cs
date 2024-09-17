namespace TodoApp.Web.TodoItem.UpdateTodoItem;

public class UpdateTodoItemResponse
{
  public int Id { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public bool IsCompleted { get; set; }
  public DateTime CreatedDate { get; set; }
}
