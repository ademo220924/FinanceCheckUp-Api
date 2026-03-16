using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.ChangePassword;
using FinanceCheckUp.Application.Models.Responses.ChangePassword;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.ChangePassword.Query.ChangePasswordOnGetSalerMain;
public class ChangePasswordOnGetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<ChangePasswordOnGetSalerMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

    public ChangePasswordOnGetSalerMainRequest RequestModel { get; set; }
}