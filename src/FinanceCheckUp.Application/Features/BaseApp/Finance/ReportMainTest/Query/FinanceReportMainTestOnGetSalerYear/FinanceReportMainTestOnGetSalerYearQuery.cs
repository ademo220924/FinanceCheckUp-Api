using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTest;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTest.Query.FinanceReportMainTestOnGetSalerYear;
public class FinanceReportMainTestOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainTestOnGetSalerYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainTestOnGetSalerYearRequest Request { get; set; }
}
