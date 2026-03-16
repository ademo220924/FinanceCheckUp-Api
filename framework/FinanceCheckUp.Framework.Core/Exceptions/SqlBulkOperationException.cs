using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUpProject.Application.Common.Exceptions;

public sealed class SqlBulkOperationException : CustomBaseException
{
    public override string MessageFormat => "Bulk Update işlemi sırasında hata oluştu : {0}";
    public override string Title => "Internal Server Error";
    public override int StatusCode => StatusCodes.Status500InternalServerError;

    public SqlBulkOperationException(string propName) : base()
    {
        MessageProps.Add("{propName}", propName);
    }
}