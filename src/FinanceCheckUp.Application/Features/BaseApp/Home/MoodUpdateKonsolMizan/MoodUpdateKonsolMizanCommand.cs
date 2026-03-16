using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateKonsolMizan;

public class MoodUpdateKonsolMizanCommand: IRequest<GenericResult<MoodUpdateKonsolMizanResponse>>
{
    public MoodUpdateKonsolMizanRequest MoodUpdateKonsolMizanRequest { get; set; }
}
