namespace DaryaVariaTest.Models.Api.Response;

public class SuccessApiResponse<T> : BaseApiResponse<T>
{
    public SuccessApiResponse(T data)
    {
        StatusCode = 200;
        Success = true;
        Data = data;
        Error = null;
    }
}

public class ErrorApiResponse<T> : BaseApiResponse<T>
{
    public ErrorApiResponse(string error, int statusCode = 400)
    {
        StatusCode = statusCode;
        Success = false;
        Error = error;
        Data = default;
    }
}
