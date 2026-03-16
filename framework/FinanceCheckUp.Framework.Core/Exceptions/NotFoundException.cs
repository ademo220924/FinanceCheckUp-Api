using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class NotFoundException : CustomBaseException
{
    public override string MessageFormat => "Kayıt bulunamadı. {objectName}: '{objectValue}'";
    public override string Title => "Not Found Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public NotFoundException(string objectName, string objectValue) : base()
    {
        MessageProps.Add("{objectName}", objectName);
        MessageProps.Add("{objectValue}", objectValue);
    }

    public NotFoundException(string objectName)
    {
        MessageProps.Add("{objectName}", objectName);
    }
}
