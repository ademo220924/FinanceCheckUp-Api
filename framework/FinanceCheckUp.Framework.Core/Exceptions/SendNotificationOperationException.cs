using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Framework.Core.Exceptions;

public sealed class SendNotificationOperationException : CustomBaseException
{
    public override string MessageFormat => "{messageText}";
    public override string Title => "Notification Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public SendNotificationOperationException(string messageText) : base()
    {
        MessageProps.Add("{messageText}", messageText);
    }
}
