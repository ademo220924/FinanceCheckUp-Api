using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTest;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTest.Query.FinanceReportMainTestOnGetCheckUrl;
public class FinanceReportMainTestOnGetCheckUrlQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainTestOnGetCheckUrlResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainTestOnGetCheckUrlRequest Request { get; set; }
}
