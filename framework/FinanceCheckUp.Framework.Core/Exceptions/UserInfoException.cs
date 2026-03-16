using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class UserInfoException : CustomBaseException
{
    public override string MessageFormat => "{messageText}";
    public override string Title => "User Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public UserInfoException(string messageText) : base()
    {
        MessageProps.Add("{messageText}", messageText);
    }
}
