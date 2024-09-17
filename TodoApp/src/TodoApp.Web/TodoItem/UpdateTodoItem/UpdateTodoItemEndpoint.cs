using FastEndpoints;
using TodoApp.UseCases.TodoItem.Commands.UpdateTodoItem;
using TodoApp.UseCases.TodoItem.Interfaces;
using TodoApp.Web.TodoItem; // Ensure ApiResponse is accessible

namespace TodoApp.Web.TodoItem.UpdateTodoItem;

public class UpdateTodoItemEndpoint
  : Endpoint<UpdateTodoItemRequest, ApiResponse<UpdateTodoItemResponse>>
{
  private readonly ITodoItemService _todoItemService;

  public UpdateTodoItemEndpoint(ITodoItemService todoItemService)
  {
    _todoItemService = todoItemService;
  }

  public override void Configure()
  {
    Put("/todo/{id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(UpdateTodoItemRequest req, CancellationToken ct)
  {
    var todoItem = await _todoItemService.GetTodoItemByIdAsync(req.Id);

    if (todoItem == null)
    {
      await SendAsync(
        ApiResponse<UpdateTodoItemResponse>.Failure(404, "Todo item not found"),
        404,
        ct
      );
      return;
    }

    var command = new UpdateTodoItemCommand(
      todoItem.Id,
      req.Title,
      req.Description,
      req.IsCompleted
    );
    var updateResult = await _todoItemService.UpdateTodoItemAsync(command);

    if (updateResult.IsSuccess)
    {
      var response = new UpdateTodoItemResponse
      {
        Id = todoItem.Id,
        Title = req.Title,
        Description = req.Description,
        IsCompleted = req.IsCompleted,
        CreatedDate = todoItem.CreatedDate,
      };
      await SendOkAsync(
        ApiResponse<UpdateTodoItemResponse>.Success(response, "Update successful"),
        ct
      );
    }
    else
    {
      var errorResponse = new UpdateTodoItemResponse
      {
        Id = todoItem.Id,
        Title = req.Title,
        Description = req.Description,
        IsCompleted = req.IsCompleted,
        CreatedDate = todoItem.CreatedDate,
      };
      await SendAsync(
        ApiResponse<UpdateTodoItemResponse>.Failure(500, "Internal Server Error"),
        500,
        ct
      );
    }
  }
}
