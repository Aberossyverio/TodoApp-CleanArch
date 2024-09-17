using FastEndpoints;
using TodoApp.UseCases.TodoItem.Commands.DeleteTodoItem;
using TodoApp.UseCases.TodoItem.Interfaces;
using TodoApp.Web.TodoItem; // Ensure the namespace where ApiResponse is located is included

namespace TodoApp.Web.TodoItem.DeleteTodoItem;

public class DeleteTodoItemEndpoint : Endpoint<DeleteTodoItemRequest, ApiResponse<DeleteTodoItemResponse>>
{
  private readonly ITodoItemService _todoItemService;

  public DeleteTodoItemEndpoint(ITodoItemService todoItemService)
  {
    _todoItemService = todoItemService;
  }

  public override void Configure()
  {
    Delete("/todo/{id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteTodoItemRequest req, CancellationToken ct)
  {
    var command = new DeleteTodoItemCommand(req.Id);
    var result = await _todoItemService.DeleteTodoItemAsync(command);

    if (result.IsSuccess)
    {
      var response = new DeleteTodoItemResponse { Message = "Todo item deleted successfully." };
      await SendAsync(ApiResponse<DeleteTodoItemResponse>.Success(response, "Operation successful"), 200, ct);
    }
    else
    {
      var errorResponse = ApiResponse<DeleteTodoItemResponse>.Failure(404, "Todo item not found");
      await SendAsync(errorResponse, errorResponse.StatusCode, ct);
    }
  }
}
