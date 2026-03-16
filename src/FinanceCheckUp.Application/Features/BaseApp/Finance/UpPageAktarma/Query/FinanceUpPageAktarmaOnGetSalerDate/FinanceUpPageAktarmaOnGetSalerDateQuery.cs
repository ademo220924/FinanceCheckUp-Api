using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarma;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerDate;
public class FinanceUpPageAktarmaOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpPageAktarmaOnGetSalerDateResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpPageAktarmaOnGetSalerDateRequest Request { get; set; }
    public FinanceUpPageAktarmaRequestInitialModel InitialModel { get; set; }
}
