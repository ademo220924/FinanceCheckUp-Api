using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOne;

public class MoodUploadOneCommand: IRequest<GenericResult<MoodUploadOneResponse>>
{
    public MoodUploadOneRequest MoodUploadOneRequest { get; set; }
}
