using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.UserList;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.UserList;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserList.Query.UserListOnGet;

public class UserListOnGetQuery : IUserIdAssignable , IRequest<GenericResult<UserListOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public UserListOnGetRequest Request { get; set; }
}

