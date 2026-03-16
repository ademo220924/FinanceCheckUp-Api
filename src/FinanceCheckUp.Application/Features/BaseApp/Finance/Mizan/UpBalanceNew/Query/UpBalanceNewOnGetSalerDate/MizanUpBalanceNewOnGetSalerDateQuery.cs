using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetSalerDate
{
    public class MizanUpBalanceNewOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpBalanceNewOnGetSalerDateResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpBalanceNewOnGetSalerDateRequest Request { get; set; }
        public MizanUpBalanceNewRequestInitialModel InitialModel { get; set; }
    }
}