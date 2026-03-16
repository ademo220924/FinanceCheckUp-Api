using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTest;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTest.Query.FinanceReportMainTestOnGetCheckRepPdf;
public class FinanceReportMainTestOnGetCheckRepPdfQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainTestOnGetCheckRepPdfResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainTestOnGetCheckRepPdfRequest Request { get; set; }
    public FinanceReportMainTestRequestInitialModel InitialModel { get; set; }
}
