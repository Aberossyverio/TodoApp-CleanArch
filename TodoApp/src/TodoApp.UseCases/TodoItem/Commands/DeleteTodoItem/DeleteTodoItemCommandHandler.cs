using TodoApp.Core.TodoItem.Repositories;

namespace TodoApp.UseCases.TodoItem.Commands.DeleteTodoItem;

public class DeleteTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
{
  private readonly ITodoItemRepository _todoItemRepository = todoItemRepository;

  public async Task Handle(DeleteTodoItemCommand command)
  {
    // Check if the TodoItem exists
    var todoItem = await _todoItemRepository.GetByIdAsync(command.Id);

    if (todoItem != null)
    {
      // Delete the TodoItem using its Id
      await _todoItemRepository.DeleteAsync(command.Id);
    }
    else
    {
      // Handle the case where the TodoItem does not exist (optional)
      throw new Exception($"TodoItem with Id {command.Id} not found.");
    }
  }
}
