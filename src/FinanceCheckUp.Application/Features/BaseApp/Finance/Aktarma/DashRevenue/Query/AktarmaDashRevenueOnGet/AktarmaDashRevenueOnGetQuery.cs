using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashRevenue.Query.AktarmaDashRevenueOnGet;
public class AktarmaDashRevenueOnGetQuery : IUserIdAssignable , IRequest<GenericResult<AktarmaDashRevenueOnGetResponse>>
{
    public AktarmaDashRevenueOnGetRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}

