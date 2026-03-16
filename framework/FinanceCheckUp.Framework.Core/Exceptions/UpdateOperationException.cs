using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class UpdateOperationException : CustomBaseException
{
    public override string MessageFormat => "{modelName} nesnesi veritabanında güncellenirken hata oluştu. Model : {modelValue}";
    public override string Title => "Update Operation Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public UpdateOperationException(string modelName, object modelValue) : base()
    {
        MessageProps.Add("{modelName}", modelName);
        MessageProps.Add("{modelValue}", JsonSerializer.Serialize(modelValue));
    }
}
