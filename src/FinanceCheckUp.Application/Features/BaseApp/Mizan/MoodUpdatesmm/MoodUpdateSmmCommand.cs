using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesmm;

public class MoodUpdateSmmCommand(XMlookUpdate xMlookUpdate) : IRequest<GenericResult<MoodUpdateSmmResponse>>
{
    public XMlookUpdate XMlookUpdate { get; set; } = xMlookUpdate;
}