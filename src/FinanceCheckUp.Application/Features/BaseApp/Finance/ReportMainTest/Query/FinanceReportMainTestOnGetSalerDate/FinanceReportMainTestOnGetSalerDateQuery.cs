using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTest;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTest.Query.FinanceReportMainTestOnGetSalerDate;
public class FinanceReportMainTestOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainTestOnGetSalerDateResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainTestOnGetSalerDateRequest Request { get; set; }
    public FinanceReportMainTestRequestInitialModel InitialModel { get; set; }
}
