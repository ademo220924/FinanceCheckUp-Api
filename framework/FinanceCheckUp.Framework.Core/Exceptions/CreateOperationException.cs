using FinanceCheckUp.Framework.Core.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FinanceCheckUp.Framework.Core.Exceptions;

[Serializable]
public sealed class CreateOperationException : CustomBaseException
{
    public override string MessageFormat => "$modelName$ nesnesi veritabanına eklenirken hata oluştu. Model : $modelValue$";
    public override string Title => "Create Operation Error";
    public override int StatusCode => StatusCodes.Status400BadRequest;

    public CreateOperationException(string modelName, object modelValue) : base()
    {
        MessageProps.Add("$modelName$", modelName);
        MessageProps.Add("$modelValue$", JsonConvert.SerializeObject(modelValue));
    }
}
