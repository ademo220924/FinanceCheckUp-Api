using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class FileTypeException : CustomBaseException
{
    public override string MessageFormat => "Bu işlem için {extension} uzantılı dosya kullanılamaz.";
    public override string Title => "File Type Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public FileTypeException(string extension) : base()
    {
        MessageProps.Add("{extension}", extension);
    }
}
