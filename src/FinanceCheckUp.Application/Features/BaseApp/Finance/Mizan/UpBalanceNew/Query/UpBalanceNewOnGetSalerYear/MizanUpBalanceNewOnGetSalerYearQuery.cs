using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetSalerYear
{
    public class MizanUpBalanceNewOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpBalanceNewOnGetSalerYearResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpBalanceNewOnGetSalerYearRequest Request { get; set; }
    }
}
