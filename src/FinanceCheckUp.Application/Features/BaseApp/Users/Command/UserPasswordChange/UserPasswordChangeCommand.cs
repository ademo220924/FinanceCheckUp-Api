using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.UserPasswordChange;

public class UserPasswordChangeCommand : IUserIdAssignable , IRequest<GenericResult<UserPasswordChangeResponse>>
{
    public int Id { get; set; }
    public string Password { get; set; }

    [JsonIgnore] public  string UserId { get; set; }
}