namespace TodoApp.Core.TodoItem.Commands
{
    public class DeleteTodoItemCommand
    {
        public int Id { get; set; }
        
        // Constructor
        public DeleteTodoItemCommand(int id)
        {
            Id = id;
        }
    }
}
