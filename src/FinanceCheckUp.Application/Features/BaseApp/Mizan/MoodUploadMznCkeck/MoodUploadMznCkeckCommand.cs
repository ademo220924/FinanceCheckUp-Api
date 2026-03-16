using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMznCkeck;

public class MoodUploadMznCkeckCommand : IRequest<GenericResult<MoodUploadMznCkeckResponse>>
{
    public MoodUploadMznCkeckCommand()
    {
    }

    public MoodUploadMznCkeckCommand(XMlook xMlook)
    {
        XMlook = xMlook;
    }

    public XMlook XMlook { get; set; }
}