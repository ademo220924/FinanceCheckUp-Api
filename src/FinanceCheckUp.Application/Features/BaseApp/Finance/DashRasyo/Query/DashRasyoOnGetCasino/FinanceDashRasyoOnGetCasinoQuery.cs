using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRasyo.Query.DashRasyoOnGetCasino
{
    public class FinanceDashRasyoOnGetCasinoQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashRasyoOnGetCasinoResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public FinanceDashRasyoOnGetCasinoRequest Request { get; set; }
        public FinanceDashRasyoRequestInitialModel InitialModel { get; set; }
    }
}
