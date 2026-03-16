using System.Net;

namespace FinanceCheckUp.Framework.Core.Exceptions.Default;

[Serializable]
public class ArgumentValidationException : Exception
{
    public int StatusCode => (int)HttpStatusCode.BadRequest;
    public List<string> MessageProps { get; } = new();

    public ArgumentValidationException(List<string> errors) : base()
    {
        MessageProps.AddRange(errors);
    }
}
