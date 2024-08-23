namespace TodoApp.Core.TodoItem.Commands;

public class UpdateTodoItemCommand{
  public int Id { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public bool IsCompleted { get; set; }

  //Constuctor
  public UpdateTodoItemCommand(int id, string title, string description, bool isCompleted) { 
    Id = id; Title = title; Description = description; IsCompleted = isCompleted;
  }
}
