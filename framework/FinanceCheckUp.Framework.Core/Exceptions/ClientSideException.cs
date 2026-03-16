using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class ClientSideException : CustomBaseException
{
    public override string MessageFormat => "Client : {clientName} - {processName} işlemi sırasında bir hata oluştu.";
    public override string Title => "Client Side Error";
    public override int StatusCode => StatusCodes.Status500InternalServerError;

    public ClientSideException(string clientName, string processName) : base()
    {
        MessageProps.Add("{clientName}", clientName);
        MessageProps.Add("{processName}", processName);
    }
}
