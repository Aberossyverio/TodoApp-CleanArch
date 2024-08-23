using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.TodoItem.Models;
using TodoApp.Core.TodoItem.Repositories;

namespace TodoApp.Core.TodoItem.Services;

  public class TodoItemService : ITodoItemService
  {
      private readonly ITodoItemRepository _repository;

      public TodoItemService(ITodoItemRepository repository)
      {
          _repository = repository;
      }

      public async Task<Todo> GetTodoItemByIdAsync(int id)
      {
          return await _repository.GetByIdAsync(id);
      }

      public async Task<IEnumerable<Todo>> GetAllTodoItemsAsync()
      {
          return await _repository.GetAllAsync();
      }

      public async Task AddTodoItemAsync(Todo todoItem)
      {
          await _repository.AddAsync(todoItem);
      }

      public async Task UpdateTodoItemAsync(Todo todoItem)
      {
          await _repository.UpdateAsync(todoItem);
      }

      public async Task DeleteTodoItemAsync(int id)
      {
          await _repository.DeleteAsync(id);
      }
  }
