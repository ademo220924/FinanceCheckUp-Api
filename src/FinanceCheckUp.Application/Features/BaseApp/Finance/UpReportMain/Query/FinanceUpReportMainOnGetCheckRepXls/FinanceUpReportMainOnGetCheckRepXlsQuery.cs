using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpReportMain.Query.FinanceUpReportMainOnGetCheckRepXls;
public class FinanceUpReportMainOnGetCheckRepXlsQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpReportMainOnGetCheckRepXlsResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpReportMainOnGetCheckRepXlsRequest Request { get; set; }
    public FinanceUpReportMainRequestInitialModel InitialModel { get; set; }
}
