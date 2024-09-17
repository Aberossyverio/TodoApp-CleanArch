namespace TodoApp.Web.TodoItem.GetTodoItemById;

using FastEndpoints;
using TodoApp.UseCases.TodoItem.Interfaces;

public class GetTodoItemByIdEndpoint
  : Endpoint<GetTodoItemByIdRequest, ApiResponse<GetTodoItemByIdResponse>>
{
  private readonly ITodoItemService _todoItemService;

  public GetTodoItemByIdEndpoint(ITodoItemService todoItemService)
  {
    _todoItemService = todoItemService;
  }

  public override void Configure()
  {
    Get("/todo/{id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetTodoItemByIdRequest req, CancellationToken ct)
  {
    var todoItem = await _todoItemService.GetTodoItemByIdAsync(req.Id);

    if (todoItem == null)
    {
      var notFoundResponse = ApiResponse<GetTodoItemByIdResponse>.Failure(
        404,
        "Todo item not found."
      );
      await SendAsync(notFoundResponse, 404, ct);
      return;
    }

    var response = ApiResponse<GetTodoItemByIdResponse>.Success(
      new GetTodoItemByIdResponse { TodoItems = todoItem },
      "Todo item retrieved successfully."
    );
    await SendOkAsync(response, ct);
  }
}
