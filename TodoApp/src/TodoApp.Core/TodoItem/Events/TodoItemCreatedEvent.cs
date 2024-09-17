namespace TodoApp.Core.TodoItem.Events;

  public class TodoItemCreatedEvent(int id, string title, string description, DateTime createdDate)
{
  public int Id { get; } = id;
  public string Title { get; } = title;
  public string Description { get; } = description;
  public DateTime CreatedDate { get; } = createdDate;
}
