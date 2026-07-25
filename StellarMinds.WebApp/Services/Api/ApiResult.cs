namespace StellarMinds.WebApp.Services.Api;

public class ApiResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }

    public static ApiResult Ok() => new() { Success = true };
    public static ApiResult Error(string message) => new() { Success = false, ErrorMessage = message };
}

public class ApiResult<T> : ApiResult
{
    public T? Data { get; set; }

    public static ApiResult<T> Ok(T data) => new() { Success = true, Data = data };
    public new static ApiResult<T> Error(string message) => new() { Success = false, ErrorMessage = message };
}
