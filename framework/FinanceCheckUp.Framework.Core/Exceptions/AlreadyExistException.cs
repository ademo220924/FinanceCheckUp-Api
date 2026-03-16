using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class AlreadyExistException : CustomBaseException
{
    public override string MessageFormat => "{propName} : '{propValue}' ile bir {objectName} kaydı mevcut.";
    public override string Title => "Already Exist Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public AlreadyExistException(string propName, string propValue, string objectName) : base()
    {
        MessageProps.Add("{propName}", propName);
        MessageProps.Add("{propValue}", propValue);
        MessageProps.Add("{objectName}", objectName);
    }
}
