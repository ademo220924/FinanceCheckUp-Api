using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaSelectedByn;

public class MoodUpdatesAktarmaSelectedBynCommand(XMlookUpdate xMlookUpdate) : IRequest<GenericResult<MoodUpdateSaktarmaSelectedByNResponse>>
{
    public XMlookUpdate XMlookUpdate { get; set; } = xMlookUpdate;
}