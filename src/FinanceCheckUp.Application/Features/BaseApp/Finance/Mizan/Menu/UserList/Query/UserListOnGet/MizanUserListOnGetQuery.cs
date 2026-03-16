using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserList;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserList;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserList.Query.UserListOnGet;

public class MizanUserListOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanUserListOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanUserListOnGetRequest Request { get; set; }
}

