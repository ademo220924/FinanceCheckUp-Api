using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateKonsol;

public class MoodUpdateKonsolCommand: IRequest<GenericResult<MoodUpdateKonsolResponse>>
{
    public MoodUpdateKonsolRequest MoodUpdateKonsolRequest { get; set; }
}
