using TodoApp.UseCases.DTOs;

namespace TodoApp.Web.TodoItem.GetAllTodoitem;

public class GetAllTodoItemResponse
{
    public required IEnumerable<TodoItemDTO> TodoItems { get; set; }
}
