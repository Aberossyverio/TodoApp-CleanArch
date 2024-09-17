
using Ardalis.Result;
using TodoApp.UseCases.DTOs;
using TodoApp.UseCases.TodoItem.Commands.CreateTodoItem;
using TodoApp.UseCases.TodoItem.Commands.DeleteTodoItem;
using TodoApp.UseCases.TodoItem.Commands.UpdateTodoItem;

namespace TodoApp.UseCases.TodoItem.Interfaces;

  public interface ITodoItemService
  {
      Task<TodoItemDTO?> GetTodoItemByIdAsync(int id);
      Task<IEnumerable<TodoItemDTO>> GetAllTodoItemsAsync();
      Task<TodoItemDTO> CreateTodoItemAsync(CreateTodoItemCommand command);
      Task<Result> UpdateTodoItemAsync(UpdateTodoItemCommand command);
      Task<Result> DeleteTodoItemAsync(DeleteTodoItemCommand command);
  }

