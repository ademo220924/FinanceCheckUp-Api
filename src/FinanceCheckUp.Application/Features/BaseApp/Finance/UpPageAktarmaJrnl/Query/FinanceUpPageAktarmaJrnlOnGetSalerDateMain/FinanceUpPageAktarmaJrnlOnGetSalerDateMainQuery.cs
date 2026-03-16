using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaJrnl.Query.FinanceUpPageAktarmaJrnlOnGetSalerDateMain;
public class FinanceUpPageAktarmaJrnlOnGetSalerDateMainQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerDateMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpPageAktarmaJrnlOnGetSalerDateMainRequest Request { get; set; }
    public FinanceUpPageAktarmaJrnlRequestInitialModel InitialModel { get; set; }
}
