namespace TodoApp.UseCases.TodoItem.Commands.CreateTodoItem;

  public class CreateTodoItemCommand(string title, string description, DateTime createdDate)
{
  // Properties
  public string Title { get; set; } = title;
  public string Description { get; set; } = description;
  public DateTime CreatedDate { get; set; } = createdDate;
}
