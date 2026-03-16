using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Upload;
using FinanceCheckUp.Application.Models.Responses.Finance.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Upload.Query.FinanceUploadMainOnGetSalerMainNote;
public class FinanceUploadMainOnGetSalerMainNoteQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUploadMainOnGetSalerMainNoteResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUploadMainOnGetSalerMainNoteRequest Request { get; set; }
    public FinanceUploadMainRequestInitialModel InitialModel { get; set; }
}
