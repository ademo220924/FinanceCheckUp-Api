using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Upload;
using FinanceCheckUp.Application.Models.Responses.Finance.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Upload.Query.FinanceUploadMainOnGet;
public class FinanceUploadMainOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUploadMainOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUploadMainOnGetRequest Request { get; set; }
}
