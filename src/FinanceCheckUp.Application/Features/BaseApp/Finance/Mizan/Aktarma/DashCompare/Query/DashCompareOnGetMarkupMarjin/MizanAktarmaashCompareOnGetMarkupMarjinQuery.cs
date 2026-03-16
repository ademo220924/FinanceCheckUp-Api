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

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashCompare.Query.DashCompareOnGetMarkupMarjin;
public class MizanAktarmaashCompareOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<MizanAktarmaDashCompareOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanAktarmaDashCompareOnGetMarkupMarjinRequest Request { get; set; }
    public MizanAktarmaDashCompareRequestInitialModel InitialModel { get; set; }
}
