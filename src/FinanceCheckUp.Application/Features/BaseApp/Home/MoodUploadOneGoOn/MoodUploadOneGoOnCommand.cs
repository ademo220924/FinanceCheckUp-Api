using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOneGoOn;

public class MoodUploadOneGoOnCommand: IRequest<GenericResult<MoodUploadOneGoOnResponse>>
{
    public MoodUploadOneGoOnRequest MoodUploadOneGoOnRequest { get; set; }
}
