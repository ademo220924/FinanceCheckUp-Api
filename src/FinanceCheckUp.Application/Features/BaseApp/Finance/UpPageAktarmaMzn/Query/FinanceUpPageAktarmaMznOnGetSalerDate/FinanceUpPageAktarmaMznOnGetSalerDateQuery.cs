using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaMzn;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaMzn.Query.FinanceUpPageAktarmaMznOnGetSalerDate;
public class FinanceUpPageAktarmaMznOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpPageAktarmaMznOnGetSalerDateResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpPageAktarmaMznOnGetSalerDateRequest Request { get; set; }
    public FinanceUpPageAktarmaMznRequestInitialModel InitialModel { get; set; }
}
