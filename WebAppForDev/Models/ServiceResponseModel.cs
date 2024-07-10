namespace WebAppForDev;

public class ServiceResponseModel<T> //O T significa que é um tipo genérico, ou seja, pode ser qualquer tipo de dado
{
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
}
