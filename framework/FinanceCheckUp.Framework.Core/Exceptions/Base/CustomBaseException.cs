namespace FinanceCheckUp.Framework.Core.Exceptions.Base;


public abstract class CustomBaseException : Exception
{
    public virtual string MessageFormat { get; } = null!;
    public virtual string Title { get; } = null!;
    public virtual int StatusCode { get; } = 500;//kontrol sağla
    public virtual Dictionary<string, string> MessageProps { get; set; } = new();
}