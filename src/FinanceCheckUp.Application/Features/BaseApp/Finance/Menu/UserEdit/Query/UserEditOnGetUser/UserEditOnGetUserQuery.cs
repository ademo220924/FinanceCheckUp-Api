using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.UserEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserEdit.Query.UserEditOnGetUser
{
    public class UserEditOnGetUserQuery : IUserIdAssignable , IRequest<GenericResult<UserEditOnGetUserResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public UserEditOnGetUserRequest Request { get; set; }
    }
}