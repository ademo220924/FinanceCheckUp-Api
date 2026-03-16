using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class FileFormatException : CustomBaseException
{
    public override string MessageFormat => "{extension} dosyası doğru formatta değil.";
    public override string Title => "File Format Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public FileFormatException(string extension) : base()
    {
        MessageProps.Add("{extension}", extension);
    }
}
