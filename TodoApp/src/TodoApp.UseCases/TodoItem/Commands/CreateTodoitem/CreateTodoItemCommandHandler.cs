using TodoApp.Core.TodoItem.Models;
using TodoApp.Core.TodoItem.Repositories;

namespace TodoApp.UseCases.TodoItem.Commands.CreateTodoItem;

public class CreateTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
{
    private readonly ITodoItemRepository _todoItemRepository = todoItemRepository;

    public async Task Handle(CreateTodoItemCommand command)
    {
        // Create a new TodoItem model instance
        var todoItem = new Todo
        {
            Title = command.Title,
            Description = command.Description,
            CreatedDate = command.CreatedDate
        };

        // Save the new TodoItem using the repository
        await _todoItemRepository.AddAsync(todoItem);
    }
}
