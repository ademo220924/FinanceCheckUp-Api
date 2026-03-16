using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashCompare;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashCompare;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashCompare.Query.DashCompareOnGet;
public class MizanAktarmaDashCompareOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanAktarmaDashCompareOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanAktarmaDashCompareOnGetRequest Request { get; set; }
}