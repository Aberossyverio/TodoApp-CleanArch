using FastEndpoints;
using TodoApp.UseCases.TodoItem.Interfaces;
using TodoApp.Web.TodoItem;
using TodoApp.Web.TodoItem.GetAllTodoitem;

namespace TodoApp.Web.TodoItem.GetAllTodoItem;

public class GetAllTodoItemEndpoint : EndpointWithoutRequest<ApiResponse<GetAllTodoItemResponse>>
{
  private readonly ITodoItemService _todoItemService;

  public GetAllTodoItemEndpoint(ITodoItemService todoItemService)
  {
    _todoItemService = todoItemService;
  }

  public override void Configure()
  {
    Get("/todo");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var todoItems = await _todoItemService.GetAllTodoItemsAsync();

    if (todoItems == null || !todoItems.Any())
    {
      var notFoundResponse = ApiResponse<GetAllTodoItemResponse>.Failure(
        404,
        "No todo items found."
      );
      await SendAsync(notFoundResponse, 404, ct);
      return;
    }

    var response = ApiResponse<GetAllTodoItemResponse>.Success(
      new GetAllTodoItemResponse { TodoItems = todoItems },
      "Todo items retrieved successfully."
    );
    await SendOkAsync(response, ct);
  }
}
