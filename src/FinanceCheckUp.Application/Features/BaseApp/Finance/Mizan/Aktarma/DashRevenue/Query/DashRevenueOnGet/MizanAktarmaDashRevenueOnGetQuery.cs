using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashRevenue.Query.DashRevenueOnGet;
public class MizanAktarmaDashRevenueOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanAktarmaDashRevenueOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanAktarmaDashRevenueOnGetRequest Request { get; set; }
}