namespace WebAppForDev;

public class ServiceRespondeModel<T>
{
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
}
