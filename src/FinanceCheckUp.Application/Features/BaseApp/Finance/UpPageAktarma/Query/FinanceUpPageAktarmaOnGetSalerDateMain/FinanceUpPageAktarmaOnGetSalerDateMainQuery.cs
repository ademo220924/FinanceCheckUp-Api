using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarma;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerDateMain;
public class FinanceUpPageAktarmaOnGetSalerDateMainQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpPageAktarmaOnGetSalerDateMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpPageAktarmaOnGetSalerDateMainRequest Request { get; set; }
    public FinanceUpPageAktarmaRequestInitialModel InitialModel { get; set; }
}
