using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateReport;

public class MoodUpdateReportCommand: IRequest<GenericResult<MoodUpdateReportResponse>>
{
    public MoodUpdateReportRequest MoodUpdateReportRequest { get; set; }
}
