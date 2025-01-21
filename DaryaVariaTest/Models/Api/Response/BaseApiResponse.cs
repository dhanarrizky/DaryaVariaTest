namespace DaryaVariaTest.Models.Api.Response;

public abstract class BaseApiResponse<T>
{
    public int StatusCode { get; set; }
    public bool Success { get; set; } = false;
    public string? Error { get; set; }
    public T? Data { get; set; }
}
