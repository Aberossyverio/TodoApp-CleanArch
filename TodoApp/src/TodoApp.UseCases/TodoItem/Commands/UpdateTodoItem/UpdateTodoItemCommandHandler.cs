using TodoApp.Core.TodoItem.Repositories;

namespace TodoApp.UseCases.TodoItem.Commands.UpdateTodoItem;

public class UpdateTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
{
    private readonly ITodoItemRepository _todoItemRepository = todoItemRepository;

    public async Task Handle(UpdateTodoItemCommand command)
    {
        // Retrieve the TodoItem by Id
        var todoItem = await _todoItemRepository.GetByIdAsync(command.Id);

        if (todoItem != null)
        {
            // Update the TodoItem's properties
            todoItem.Title = command.Title;
            todoItem.Description = command.Description;
            todoItem.IsCompleted = command.IsCompleted;

            // Save the updated TodoItem back to the repository
            await _todoItemRepository.UpdateAsync(todoItem);
        }
        else
        {
            // Handle the case where the TodoItem does not exist (optional)
            throw new Exception($"TodoItem with Id {command.Id} not found.");
        }
    }
}
