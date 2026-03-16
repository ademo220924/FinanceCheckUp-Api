using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserEdit.Query.UserEditOnGetUser
{
    public class MizanUserEditOnGetUserQuery : IUserIdAssignable , IRequest<GenericResult<MizanUserEditOnGetUserResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUserEditOnGetUserRequest Request { get; set; }
    }
}