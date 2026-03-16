using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpload;

public class MoodUploadCommand: IRequest<GenericResult<MoodUploadResponse>>
{
    public MoodUploadRequest MoodUploadRequest { get; set; }
}
