using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpReportMain.Query.FinanceUpReportMainOnGetSalerYear;
public class FinanceUpReportMainOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpReportMainOnGetSalerYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpReportMainOnGetSalerYearRequest Request { get; set; }
}
