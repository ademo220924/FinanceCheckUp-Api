using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.ChangePassword;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.ChangePassword.Query.ChangePasswordOnGet;
public class ChangePasswordOnGetQuery : IUserIdAssignable , IRequest<GenericResult<ChangePasswordOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
}