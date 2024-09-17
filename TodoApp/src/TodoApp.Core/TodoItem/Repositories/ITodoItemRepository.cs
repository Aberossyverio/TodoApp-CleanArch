// Interface
using TodoApp.Core.TodoItem.Models;

namespace TodoApp.Core.TodoItem.Repositories;

public interface ITodoItemRepository
{
    Task<Todo> GetByIdAsync(int id);
    Task<IEnumerable<Todo>> GetAllAsync();
    Task AddAsync(Todo todoItem);
    Task UpdateAsync(Todo todoItem);
    Task DeleteAsync(int id);
}
