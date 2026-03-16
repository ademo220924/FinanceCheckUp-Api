using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdate;

public class MoodUpdateCommand: IRequest<GenericResult<MoodUpdateResponse>>
{
    public MoodUpdateRequest MoodUpdateRequest { get; set; }
}
