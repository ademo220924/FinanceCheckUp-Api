using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadBeyannameCheck;

public class MoodUploadBeyannameCheckCommand : IUserIdAssignable , IRequest<GenericResult<BeyannameMoodUploadCheckResponse>>
{
    public MoodUploadBeyannameCheckCommand()
    {

    }
    public MoodUploadBeyannameCheckCommand(XMlook xMlook)
    {
        XMlook = xMlook;
    }

    [JsonIgnore] public  string UserId { get; set; }
    public XMlook XMlook { get; set; }
}
