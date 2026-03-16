using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashRevenue.Query.AktarmaDashRevenueOnGetMarkupMarjin;

public class AktarmaDashRevenueOnGetMarkupMarjinQuery : IUserIdAssignable ,  IRequest<GenericResult<AktarmaDashRevenueOnGetMarkupMarjinResponse>>
{
    public AktarmaDashRevenueOnGetMarkupMarjinRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
    public AktarmaDashRevenueInitialModel InitialModel { get; set; }
}
