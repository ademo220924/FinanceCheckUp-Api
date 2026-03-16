using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaJrnl.Query.FinanceUpPageAktarmaJrnlOnGetGraphCode;
public class FinanceUpPageAktarmaJrnlOnGetGraphCodeQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpPageAktarmaJrnlOnGetGraphCodeResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpPageAktarmaJrnlOnGetGraphCodeRequest Request { get; set; }
    public FinanceUpPageAktarmaJrnlRequestInitialModel InitialModel { get; set; }
}
