using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOneProcess;

public class MoodUploadOneProcessCommand: IRequest<GenericResult<MoodUploadOneProcessResponse>>
{
    public MoodUploadOneProcessRequest MoodUploadOneProcessRequest { get; set; }
}
