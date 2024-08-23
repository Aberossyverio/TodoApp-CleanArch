namespace TodoApp.Core.TodoItem.Commands;

public class CreateTodoItemCommand
{
  public required string Title { get; set; }
  public required string Description { get; set; }
  public DateTime CreatedDate { get; set; }

  // Constructor
  public CreateTodoItemCommand(string title, string description, DateTime createdDate)
  {
    Title = title; Description = description; CreatedDate = createdDate;
  }
}
