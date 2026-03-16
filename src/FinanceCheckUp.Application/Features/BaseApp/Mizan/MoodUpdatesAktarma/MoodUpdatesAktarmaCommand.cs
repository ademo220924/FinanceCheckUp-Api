using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarma;

public class MoodUpdatesAktarmaCommand(XMlookUpdate xMlookUpdate) : IRequest<GenericResult<MoodUpdatesAktarmaResponse>>
{
    public XMlookUpdate XMlookUpdate { get; set; } = xMlookUpdate;
}