using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Upload;
using FinanceCheckUp.Application.Models.Responses.Finance.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Upload.Query.FinanceUploadMainOnGetSalerComp;
public class FinanceUploadMainOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUploadMainOnGetSalerCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUploadMainOnGetSalerCompRequest Request { get; set; }
    public FinanceUploadMainRequestInitialModel InitialModel { get; set; }
}
