using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerComp;
public class MizanUpPageAktarmaJrnlOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpPageAktarmaJrnlOnGetSalerCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanUpPageAktarmaJrnlOnGetSalerCompRequest Request { get; set; }
    public MizanUpPageAktarmaJrnlRequestInitialModel InitialModel { get; set; }
}
