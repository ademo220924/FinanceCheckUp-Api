using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaMzn;
public class MoodUpdatesAktarmaMznCommand(XMlookUpdate xMlookUpdate) : IRequest<GenericResult<MoodUpdatesAktarmaMznResponse>>
{
    public XMlookUpdate XMlookUpdate { get; set; } = xMlookUpdate;
}