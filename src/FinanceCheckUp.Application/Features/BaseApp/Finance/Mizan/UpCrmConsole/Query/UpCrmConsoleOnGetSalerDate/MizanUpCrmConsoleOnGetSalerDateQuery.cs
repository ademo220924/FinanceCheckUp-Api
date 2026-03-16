using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpCrmConsole;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpCrmConsole.Query.UpCrmConsoleOnGetSalerDate
{
    public class MizanUpCrmConsoleOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpCrmConsoleOnGetSalerDateResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpCrmConsoleOnGetSalerDateRequest Request { get; set; }
        public MizanUpCrmConsoleRequestInitialModel InitialModel { get; set; }
    }
}
