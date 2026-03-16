using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadUpdate;

public class MoodUploadUpdateCommand : IUserIdAssignable , IRequest<GenericResult<MoodUploadUpdateResponse>>
{
    public MoodUploadUpdateCommand()
    {

    }
    public MoodUploadUpdateCommand(XMlook xMlook)
    {
        XMlook = xMlook;
    }

    public XMlook XMlook { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}

public class MoodUploadUpdateCommandExample : IExamplesProvider<MoodUploadUpdateCommand>
{
    public MoodUploadUpdateCommand GetExamples()
    {
        return new MoodUploadUpdateCommand
        {
            XMlook = new XMlook
            {
                Caption = "",
                file = [],
                id = 1,
                ide = "ide",
                idexml = "idemxml"
            },
            UserId="13"
        };
    }
}