using TodoApp.Core.TodoItem.Models;
using TodoApp.Core.TodoItem.Repositories;


namespace TodoApp.UseCases.TodoItem.Queries.GetTodoItemByIdQuery;

public class GetTodoItemByIdQueryHandler(ITodoItemRepository todoItemRepository)
{
    private readonly ITodoItemRepository _todoItemRepository = todoItemRepository;

    public async Task<Todo> Handle(GetTodoItemByIdQuery query)
    {
        // Retrieve the TodoItem by Id
        return await _todoItemRepository.GetByIdAsync(query.Id);
    }
}
