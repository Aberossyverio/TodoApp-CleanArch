using TodoApp.Core.TodoItem.Models;
using TodoApp.Core.TodoItem.Repositories;

namespace TodoApp.UseCases.TodoItem.Queries.GetAllTodoItems;

public class GetAllTodoItemsQueryHandler(ITodoItemRepository todoItemRepository)
{
    private readonly ITodoItemRepository _todoItemRepository = todoItemRepository;

    public async Task<IEnumerable<Todo>> Handle(GetAllTodoItemsQuery query)
    {
        // Retrieve all TodoItems
        return await _todoItemRepository.GetAllAsync();
    }
}
