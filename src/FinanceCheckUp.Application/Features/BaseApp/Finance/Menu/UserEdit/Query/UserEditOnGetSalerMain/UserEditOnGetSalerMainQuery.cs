using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.UserEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserEdit.Query.UserEditOnGetSalerMain
{
    public class UserEditOnGetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<UserEditOnGetSalerMainResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public UserEditOnGetSalerCityRequest Request { get; set; }
        public UserEditInitialModel InitialModel { get; set; }
    }
}