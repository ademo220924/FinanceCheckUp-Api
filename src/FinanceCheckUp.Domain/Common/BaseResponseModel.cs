namespace FinanceCheckUp.Domain.Common;
public class BaseResponseModel<T>
{
    public int ResultCode { get; set; } = 1;
    public int ExceptionCode { get; set; } = 0;
    public string? Description { get; set; } = string.Empty;
    public T? Data { get; set; }
}
