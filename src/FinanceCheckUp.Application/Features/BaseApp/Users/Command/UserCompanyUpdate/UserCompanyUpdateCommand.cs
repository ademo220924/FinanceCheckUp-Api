using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.UserCompanyUpdate;

public class UserCompanyUpdateCommand : IUserIdAssignable , IRequest<GenericResult<UserCompanyUpdateResponse>>
{
    public UserCompanyUpdateRequest Model { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}