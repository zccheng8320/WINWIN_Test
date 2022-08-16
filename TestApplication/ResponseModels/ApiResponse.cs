using System.Text.Json.Serialization;

namespace TestApplication.ResponseModels;

public class ApiResponse
{
    protected ApiResponse()
    {
    }

    /// <summary>
    ///     代碼
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; private set; }

    /// <summary>
    ///     訊息
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; private set; }

    /// <summary>
    ///     資料(永遠為Null)
    /// </summary>
    [JsonPropertyName("data")]

    public virtual object? Data { get; } = null;

    public static ApiResponse Ok()
    {
        return new ApiResponse
        {
            Code = "200",
            Message = "ok"
        };
    }
    public static ApiResponse<T> Ok<T>(T data)
    {
        return ApiResponse<T>.Ok(data);
    }
    public static ApiResponse Failure()
    {
        return new ApiResponse
        {
            Code = "400",
            Message = "Bad Request"
        };
    }
    protected void SetSuccess()
    {
        Code = "200";
        Message = "ok";
    }
}

public class ApiResponse<T> : ApiResponse
{
    /// <summary>
    ///     Default Constructor
    /// </summary>
    protected ApiResponse(T data)
    {
        GenericData = data;
    }

    /// <summary>
    ///     資料
    /// </summary>
    [JsonIgnore]
    public override object Data => GenericData;

    /// <summary>
    ///     資料
    /// </summary>
    [JsonPropertyName("data")]
    public T GenericData { get; }

    public static ApiResponse<T> Ok(T data)
    {
        var api = new ApiResponse<T>(data);
        api.SetSuccess();
        return api;
    }

}