using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateAccountCheck;

public class MoodUpdateAccountCheckCommand: IRequest<GenericResult<MoodUpdateAccountCheckResponse>>
{
    public MoodUpdateAccountCheckRequest MoodUpdateAccountCheckRequest { get; set; }
}
