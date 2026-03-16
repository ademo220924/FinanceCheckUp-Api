using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportPotDynamic;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportPotDynamic;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportPotDynamic.Query.ReportPotDynamicOnGet
{
    public class MizanReportPotDynamicOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanReportPotDynamicOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanReportPotDynamicOnGetRequest Request { get; set; }
    }
}
