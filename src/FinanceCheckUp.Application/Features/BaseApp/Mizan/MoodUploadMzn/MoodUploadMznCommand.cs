using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMzn;

public class MoodUploadMznCommand : IRequest<GenericResult<MoodUploadMznResponse>>
{
    public MoodUploadMznCommand()
    {
    }

    public MoodUploadMznCommand(XMlook xMlook)
    {
        XMlook = xMlook;
    }

    public XMlook XMlook { get; set; }
}