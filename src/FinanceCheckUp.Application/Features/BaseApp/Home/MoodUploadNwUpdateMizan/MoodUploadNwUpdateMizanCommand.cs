using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadNwUpdateMizan;

public class MoodUploadNwUpdateMizanCommand: IRequest<GenericResult<MoodUploadNwUpdateMizanResponse>>
{
    public MoodUploadNwUpdateMizanRequest MoodUploadNwUpdateMizanRequest { get; set; }
}
