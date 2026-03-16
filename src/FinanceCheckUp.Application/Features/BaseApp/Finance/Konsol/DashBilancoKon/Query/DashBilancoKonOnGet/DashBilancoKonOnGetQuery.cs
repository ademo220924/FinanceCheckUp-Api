using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Konsol.DashBilancoKon;
using FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashBilancoKon;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Konsol.DashBilancoKon.Query.DashBilancoKonOnGet
{
    public class DashBilancoKonOnGetQuery : IUserIdAssignable , IRequest<GenericResult<DashBilancoKonOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public int myear { get; set; }
    }
}
