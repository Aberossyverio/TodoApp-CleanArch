using TodoApp.UseCases.DTOs;

namespace TodoApp.Web.TodoItem.GetTodoItemById;

public class GetTodoItemByIdResponse{
  public required TodoItemDTO TodoItems { get; set; }
}
