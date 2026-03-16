using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpReportMain.Query.FinanceUpReportMainOnGetCheckRepPdf;
public class FinanceUpReportMainOnGetCheckRepPdfQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpReportMainOnGetCheckRepPdfResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpReportMainOnGetCheckRepPdfRequest Request { get; set; }
    public FinanceUpReportMainRequestInitialModel InitialModel { get; set; }
}
