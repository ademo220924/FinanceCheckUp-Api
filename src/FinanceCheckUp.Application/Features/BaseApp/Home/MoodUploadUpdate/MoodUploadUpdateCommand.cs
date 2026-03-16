using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadUpdate;

public class MoodUploadUpdateCommand: IRequest<GenericResult<MoodUploadUpdateResponse>>
{
    public MoodUploadUpdateRequest MoodUploadUpdateRequest { get; set; }
}
