using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMznCkeckFileUpdate;

public class MoodUploadMznCkeckFileUpdateCommand : IRequest<GenericResult<MoodUploadMznCkeckFileUpdateResponse>>
{
    public MoodUploadMznCkeckFileUpdateCommand()
    {
    }

    public MoodUploadMznCkeckFileUpdateCommand(XMlook xMlook)
    {
        XMlook = xMlook;
    }

    public XMlook XMlook { get; set; }
}