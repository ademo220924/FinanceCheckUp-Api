using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetCheckUrl
{
    public class MizanReportMainTestMizanOldOnGetCheckUrlQuery : IUserIdAssignable , IRequest<GenericResult<MizanReportMainTestMizanOldOnGetCheckUrlResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanReportMainTestMizanOldOnGetCheckUrlRequest Request { get; set; }
    }
}
