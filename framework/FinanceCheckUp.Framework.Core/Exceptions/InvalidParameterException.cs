using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class InvalidParameterException : CustomBaseException
{
    public override string MessageFormat => "Geçersiz parametre. {fieldName} : {fieldValue}";
    public override string Title => "Invalid Parameter Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public InvalidParameterException(string fieldName, string fieldValue) : base()
    {
        MessageProps.Add("{fieldName}", fieldName);
        MessageProps.Add("{fieldValue}", fieldValue);
    }
}
