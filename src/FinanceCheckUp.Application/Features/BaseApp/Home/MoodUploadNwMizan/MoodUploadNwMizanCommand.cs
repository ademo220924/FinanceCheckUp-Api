using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadNwMizan;

public class MoodUploadNwMizanCommand: IRequest<GenericResult<MoodUploadNwMizanResponse>>
{
    public MoodUploadNwMizanRequest MoodUploadNwMizanRequest { get; set; }
}
