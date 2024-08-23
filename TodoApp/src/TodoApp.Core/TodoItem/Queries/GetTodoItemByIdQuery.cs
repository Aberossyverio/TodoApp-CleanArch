namespace TodoApp.Core.TodoItem.Queries;

  public class GetTodoItemByIdQuery
  {
      public int Id { get; }

      // Constructor
      public GetTodoItemByIdQuery(int id)
      {
          Id = id;
      }
  }
