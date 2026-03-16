using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpCrmConsole;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpCrmConsole.Query.UpCrmConsoleOnGetSalerComp
{
    public class MizanUpCrmConsoleOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpCrmConsoleOnGetSalerCompResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpCrmConsoleOnGetSalerCompRequest Request { get; set; }
    }
}
