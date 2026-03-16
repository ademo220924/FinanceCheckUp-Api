using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOneUpdate;

public class MoodUploadOneUpdateCommand: IRequest<GenericResult<MoodUploadOneUpdateResponse>>
{
    public MoodUploadOneUpdateRequest MoodUploadOneUpdateRequest { get; set; }
}
