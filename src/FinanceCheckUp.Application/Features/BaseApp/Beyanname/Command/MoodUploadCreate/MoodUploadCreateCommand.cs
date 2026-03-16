using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadCreate;

public class MoodUploadCreateCommand : IUserIdAssignable , IRequest<GenericResult<MoodUploadCreateResponse>>
{
    public MoodUploadCreateCommand()
    {

    }
    public MoodUploadCreateCommand(XMlook xMlook)
    {
        XMlook = xMlook;
    }

    public XMlook XMlook { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}

public class MoodUploadCreateCommandExample :  IExamplesProvider<MoodUploadCreateCommand>
{
    public MoodUploadCreateCommand GetExamples()
    {
        return new MoodUploadCreateCommand
        {
            XMlook = new XMlook
            {
                Caption = "",
                file = [],
                id = 1,
                ide = "ide",
                idexml = "idemxml"
            },
            UserId="12"
        };
    }
}