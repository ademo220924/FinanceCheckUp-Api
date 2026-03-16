using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaSelectedMzn;

public class MoodUpdatesAktarmaSelectedMznCommand(XMlookUpdate xMlookUpdate) : IRequest<GenericResult<MoodUpdatesAktarmaSelectedMznResponse>>
{
    public XMlookUpdate XMlookUpdate { get; set; } = xMlookUpdate;
}