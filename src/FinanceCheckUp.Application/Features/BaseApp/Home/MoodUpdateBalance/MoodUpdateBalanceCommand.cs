using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateBalance;

public class MoodUpdateBalanceCommand: IRequest<GenericResult<MoodUpdateBalanceResponse>>
{
    public MoodUpdateBalanceRequest MoodUpdateBalanceRequest { get; set; }
}
