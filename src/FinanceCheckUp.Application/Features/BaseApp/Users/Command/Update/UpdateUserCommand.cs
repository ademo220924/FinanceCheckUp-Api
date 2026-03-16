using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.Users;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.Update;

public class UpdateUserCommand : HhvnUsers,IUserIdAssignable , IRequest<GenericResult<UpdateUserResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
}
