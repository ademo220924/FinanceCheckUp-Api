using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpReportMain.Query.UpReportMainOnGetSalerComp
{
    public class MizanUpReportMainOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpReportMainOnGetSalerCompResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpReportMainOnGetSalerCompRequest Request { get; set; }
    }
}
