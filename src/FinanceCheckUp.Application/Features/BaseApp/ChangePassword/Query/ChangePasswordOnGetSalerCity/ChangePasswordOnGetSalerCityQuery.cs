using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.ChangePassword;
using FinanceCheckUp.Application.Models.Responses.ChangePassword;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.ChangePassword.Query.ChangePasswordOnGetSalerCity;
public class ChangePasswordOnGetSalerCityQuery : IUserIdAssignable , IRequest<GenericResult<ChangePasswordOnGetSalerCityResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public ChangePasswordOnGetSalerCityRequest RequestModel { get; set; }



}