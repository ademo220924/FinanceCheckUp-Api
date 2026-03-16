using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaMzn;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaMzn.Query.FinanceUpPageAktarmaMznOnGetSalerDateMain;
public class FinanceUpPageAktarmaMznOnGetSalerDateMainQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpPageAktarmaMznOnGetSalerDateMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpPageAktarmaMznOnGetSalerDateMainRequest Request { get; set; }
    public FinanceUpPageAktarmaMznRequestInitialModel InitialModel { get; set; }
}
