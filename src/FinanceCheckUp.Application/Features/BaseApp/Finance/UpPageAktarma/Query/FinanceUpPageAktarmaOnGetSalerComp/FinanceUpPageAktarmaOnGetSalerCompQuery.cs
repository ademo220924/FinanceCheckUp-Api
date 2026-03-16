using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarma;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerComp;
public class FinanceUpPageAktarmaOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpPageAktarmaOnGetSalerCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpPageAktarmaOnGetSalerCompRequest Request { get; set; }
    public FinanceUpPageAktarmaRequestInitialModel InitialModel { get; set; }
}
