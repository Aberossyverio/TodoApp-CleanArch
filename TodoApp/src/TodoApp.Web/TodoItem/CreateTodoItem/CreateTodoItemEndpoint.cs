using TodoApp.UseCases.TodoItem.Interfaces;
using TodoApp.UseCases.TodoItem.Commands.CreateTodoItem;
using FastEndpoints;
using TodoApp.Web.TodoItems.CreateTodoItem;
using TodoApp.Web.TodoItems; // Assuming ApiResponse is in this namespace

namespace TodoApp.Web.TodoItem.CreateTodoItem;

public class CreateTodoItemEndpoint : Endpoint<CreateTodoItemRequest, ApiResponse<CreateTodoItemResponse>>
{
  private readonly ITodoItemService _todoItemService;

  public CreateTodoItemEndpoint(ITodoItemService todoItemService)
  {
    _todoItemService = todoItemService;
  }

  public override void Configure()
  {
    Post("/todo");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateTodoItemRequest request, CancellationToken ct)
  {
    if (request == null)
    {
      var errorResponse = ApiResponse<CreateTodoItemResponse>.Failure(400, "Bad Request: Request data is null.");
      await SendAsync(errorResponse, 400, ct);
      return;
    }

    var command = new CreateTodoItemCommand(
        request.Title,
        request.Description,
        request.CreatedDate
    );

    var result = await _todoItemService.CreateTodoItemAsync(command);

    if (result == null)
    {
      var errorResponse = ApiResponse<CreateTodoItemResponse>.Failure(500, "Internal Server Error: Unable to create todo item.");
      await SendAsync(errorResponse, 500, ct);
      return;
    }

    var response = new CreateTodoItemResponse
    {
      Id = result.Id,
      Title = result.Title,
      Description = result.Description,
      IsCompleted = result.IsCompleted,
      CreatedDate = result.CreatedDate
    };

    var successResponse = ApiResponse<CreateTodoItemResponse>.Success(response);
    await SendAsync(successResponse, 201, ct);
  }
}
