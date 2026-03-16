using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests;
using FinanceCheckUp.Application.Models.Responses.Users;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.Create;

public class CreateUserCommand : IUserIdAssignable ,  IRequest<GenericResult<CreateUserResponse>>
{
    public CreateUserRequest Model { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}
