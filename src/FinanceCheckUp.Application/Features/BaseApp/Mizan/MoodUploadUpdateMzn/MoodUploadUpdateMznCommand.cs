using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadUpdateMzn;

public class MoodUploadUpdateMznCommand : IRequest<GenericResult<MoodUploadUpdateMznResponse>>
{
    public MoodUploadUpdateMznCommand()
    {
    }

    public MoodUploadUpdateMznCommand(XMlook xMlook)
    {
        XMlook = xMlook;
    }

    public XMlook XMlook { get; set; }
}