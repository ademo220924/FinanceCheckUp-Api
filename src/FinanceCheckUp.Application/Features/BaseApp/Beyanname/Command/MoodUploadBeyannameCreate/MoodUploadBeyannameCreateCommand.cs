using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadBeyannameCreate;

public class MoodUploadBeyannameCreateCommand : IUserIdAssignable , IRequest<GenericResult<BeyannameMoodUploadCreateResponse>>
{
    public MoodUploadBeyannameCreateCommand()
    {

    }
    public MoodUploadBeyannameCreateCommand(XMlook xMlook)
    {
        XMlook = xMlook;
    }

    public XMlook XMlook { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}
