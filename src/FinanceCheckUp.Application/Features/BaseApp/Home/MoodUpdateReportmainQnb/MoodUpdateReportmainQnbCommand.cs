using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateReportmainQnb;

public class MoodUpdateReportmainQnbCommand: IRequest<GenericResult<MoodUpdateReportmainQnbResponse>>
{
    public MoodUpdateReportmainQnbRequest MoodUpdateReportmainQnbRequest { get; set; }
}
