using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdateBalance;
public class MoodUpdateBalanceCommand(XMlookUpdate xMlookUpdate) : IRequest<GenericResult<MoodUpdateBalanceResponse>>
{
    public XMlookUpdate XMlookUpdate { get; set; } = xMlookUpdate;
}