using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.Delete;

public class UserDeleteCommand : IUserIdAssignable , IRequest<GenericResult<UserDeleteResponse>>
{
    public long Id { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}