using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.TodoItem.Models;

namespace TodoApp.Core.TodoItem.Services;

  public interface ITodoItemService
  {
      Task<Todo> GetTodoItemByIdAsync(int id);
      Task<IEnumerable<Todo>> GetAllTodoItemsAsync();
      Task AddTodoItemAsync(Todo todoItem);
      Task UpdateTodoItemAsync(Todo todoItem);
      Task DeleteTodoItemAsync(int id);
  }
