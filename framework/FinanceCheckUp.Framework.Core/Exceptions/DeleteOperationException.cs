using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class DeleteOperationException : CustomBaseException
{
    public override string MessageFormat => "{modelName} nesnesi veritabanından silinirken hata oluştu. Model : {modelValue}";
    public override string Title => "Delete Operation Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public DeleteOperationException(string modelName, object modelValue) : base()
    {
        MessageProps.Add("{modelName}", modelName);
        MessageProps.Add("{modelValue}", JsonSerializer.Serialize(modelValue));
    }
}