using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaSelected;

public class MoodUpdatesAktarmaSelectedCommand(XMlookUpdate xMlookUpdate) : IRequest<GenericResult<MoodUpdatesAktarmaSelectedResponse>>
{
    public XMlookUpdate XMlookUpdate { get; set; } = xMlookUpdate;
}