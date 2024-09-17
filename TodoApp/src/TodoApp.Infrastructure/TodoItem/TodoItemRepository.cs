using TodoApp.Core.TodoItem.Models;
using TodoApp.Core.TodoItem.Repositories;
using Microsoft.EntityFrameworkCore;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.TodoItem;

public class TodoItemRepository(AppDbContext context) : ITodoItemRepository
{
  private readonly AppDbContext _context = context;

  public async Task AddAsync(Todo todoItem)
  {
    await _context.TodoItems.AddAsync(todoItem);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(int id)
  {
    var todoItem = await _context.TodoItems.FindAsync(id);
    if (todoItem != null)
    {
      _context.TodoItems.Remove(todoItem);
      await _context.SaveChangesAsync();
    }
  }

  public async Task<IEnumerable<Todo>> GetAllAsync()
  {
    return await _context.TodoItems.ToListAsync();
  }

  public async Task<Todo> GetByIdAsync(int id)
  {
    var todo = await _context.TodoItems.FindAsync(id) ?? throw new KeyNotFoundException($"Todo item with id {id} was not found.");
    return todo;
  }

  public async Task UpdateAsync(Todo todoItem)
  {
    var existingItem = await _context.TodoItems.FindAsync(todoItem.Id);
    if (existingItem != null)
    {
      existingItem.Title = todoItem.Title;
      existingItem.Description = todoItem.Description;
      existingItem.IsCompleted = todoItem.IsCompleted;
      existingItem.CreatedDate = todoItem.CreatedDate;

      _context.TodoItems.Update(existingItem);
      await _context.SaveChangesAsync();
    }
  }
}
