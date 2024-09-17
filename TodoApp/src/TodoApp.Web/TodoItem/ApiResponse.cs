namespace TodoApp.Web.TodoItem;

public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }

    public ApiResponse(int statusCode, string message, T? data = default)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }

    public static ApiResponse<T> Success(T data, string message = "Operation successful")
    {
        return new ApiResponse<T>(200, message, data);
    }

    public static ApiResponse<T> Success(string message = "Operation successful")
    {
        return new ApiResponse<T>(200, message);
    }

    public static ApiResponse<T> Failure(int statusCode, string message)
    {
        return new ApiResponse<T>(statusCode, message);
    }
}
