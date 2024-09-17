using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.UseCases.DTOs;
using TodoApp.UseCases.TodoItem.Commands.CreateTodoItem;
using TodoApp.UseCases.TodoItem.Commands.DeleteTodoItem;
using TodoApp.UseCases.TodoItem.Commands.UpdateTodoItem;
using TodoApp.UseCases.TodoItem.Interfaces;
using TodoApp.Core.TodoItem.Models;
using TodoApp.Core.TodoItem.Repositories;
using Ardalis.Result;

namespace TodoApp.Infrastructure.TodoItem;

  public class TodoItemService : ITodoItemService
  {
      private readonly ITodoItemRepository _todoItemRepository;

      public TodoItemService(ITodoItemRepository todoItemRepository)
      {
          _todoItemRepository = todoItemRepository;
      }

      public async Task<TodoItemDTO?> GetTodoItemByIdAsync(int id)
      {
          var todoItem = await _todoItemRepository.GetByIdAsync(id);
          if (todoItem == null)
          {
              return null;
          }
          return new TodoItemDTO
          {
              Id = todoItem.Id,
              Title = todoItem.Title,
              Description = todoItem.Description,
              IsCompleted = todoItem.IsCompleted,
              CreatedDate = todoItem.CreatedDate
          };
      }

      public async Task<IEnumerable<TodoItemDTO>> GetAllTodoItemsAsync()
      {
          var todoItems = await _todoItemRepository.GetAllAsync();
          return todoItems.Select(todoItem => new TodoItemDTO
          {
              Id = todoItem.Id,
              Title = todoItem.Title,
              Description = todoItem.Description,
              IsCompleted = todoItem.IsCompleted,
              CreatedDate = todoItem.CreatedDate
          }).ToList();
      }

      public async Task<TodoItemDTO> CreateTodoItemAsync(CreateTodoItemCommand command)
      {
          var todoItem = new Todo
          {
              Title = command.Title,
              Description = command.Description,
              CreatedDate = command.CreatedDate,
              IsCompleted = false
          };

          await _todoItemRepository.AddAsync(todoItem);

          var todoItemDto = new TodoItemDTO{
            Id = todoItem.Id,
            Title = todoItem.Title,
            Description = todoItem.Description,
            CreatedDate = todoItem.CreatedDate,
            IsCompleted = todoItem.IsCompleted,
          };

          return todoItemDto;
      }

      public async Task<Result> UpdateTodoItemAsync(UpdateTodoItemCommand command)
      {
          var todoItem = await _todoItemRepository.GetByIdAsync(command.Id);
          if (todoItem == null)
          {
              return Result.Error();
          }

          todoItem.Title = command.Title;
          todoItem.Description = command.Description;
          todoItem.IsCompleted = command.IsCompleted;

          await _todoItemRepository.UpdateAsync(todoItem);

          return Result.Success();
      }

      public async Task<Result> DeleteTodoItemAsync(DeleteTodoItemCommand command)
      {
          var todoItem = await _todoItemRepository.GetByIdAsync(command.Id);
          if (todoItem == null)
          {
              return Result.Error();
          }

          await _todoItemRepository.DeleteAsync(todoItem.Id);
          return Result.Success();
      }
  }
