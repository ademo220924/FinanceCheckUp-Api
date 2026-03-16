using FinanceCheckUp.Domain.Common;

using FinanceCheckUp.Application.Models.Responses.ChangePassword;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.ChangePassword.Query.ChangePasswordOnGetUser;
public class ChangePasswordOnGetUserQuery : IUserIdAssignable , IRequest<GenericResult<ChangePasswordOnGetUserResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public string typeresult { get; set; }

}