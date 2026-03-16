using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetSalerComp
{
    public class MizanReportMainTestMizanOldOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<MizanReportMainTestMizanOldOnGetSalerCompResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanReportMainTestMizanOldOnGetSalerCompRequest Request { get; set; }
        public MizanReportMainTestMizanOldRequestInitialModel InitialModel { get; set; }
    }
}
