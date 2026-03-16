using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class DocumentTypeException : CustomBaseException
{
    public override string MessageFormat => "Döküman Tipi Hatalı . {propName} : {propValue}";
    public override string Title => "Already Exist Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public DocumentTypeException(string propName, string propValue) : base()
    {
        MessageProps.Add("{propName}", propName);
        MessageProps.Add("{propValue}", propValue);
    }
}