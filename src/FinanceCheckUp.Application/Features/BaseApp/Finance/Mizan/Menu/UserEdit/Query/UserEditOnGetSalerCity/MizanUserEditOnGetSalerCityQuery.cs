using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserEdit.Query.UserEditOnGetSalerCity
{
    public class MizanUserEditOnGetSalerCityQuery : IUserIdAssignable , IRequest<GenericResult<MizanUserEditOnGetSalerCityResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUserEditOnGetSalerCityRequest Request { get; set; }
    }
}
