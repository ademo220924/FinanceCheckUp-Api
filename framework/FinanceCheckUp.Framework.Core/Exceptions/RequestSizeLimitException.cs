using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Framework.Core.Exceptions;


[Serializable]
public sealed class RequestSizeLimitException : CustomBaseException
{
    public override string MessageFormat => "Dosya boyutu hatası. Max Dosya Boyutu :{maxSizeVaLue}";
    public override string Title => "Already Exist Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public RequestSizeLimitException(string maxSizeVaLue) : base()
    {
        MessageProps.Add("{maxSizeVaLue}", maxSizeVaLue);
    }
}