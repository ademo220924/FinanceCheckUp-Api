using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMznCkeckFileCreate;

public class MoodUploadMznCkeckFileCreateCommand : IRequest<GenericResult<MoodUploadMznCkeckFileCreateResponse>>
{
    public MoodUploadMznCkeckFileCreateCommand()
    {
    }

    public MoodUploadMznCkeckFileCreateCommand(XMlook xMlook)
    {
        XMlook = xMlook;
    }

    public XMlook XMlook { get; set; }
}