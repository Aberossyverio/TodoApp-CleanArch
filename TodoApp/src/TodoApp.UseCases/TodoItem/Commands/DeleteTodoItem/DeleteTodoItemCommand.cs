namespace TodoApp.UseCases.TodoItem.Commands.DeleteTodoItem;

public class DeleteTodoItemCommand(int id)
{
  public int Id { get; set; } = id;
}
