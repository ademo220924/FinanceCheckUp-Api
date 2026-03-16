using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.ChangePassword;
using FinanceCheckUp.Application.Models.Responses.ChangePassword;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.ChangePassword.Query.ChangePasswordOnGetSalerCompany;
public class ChangePasswordOnGetSalerCompanyQuery : IUserIdAssignable , IRequest<GenericResult<ChangePasswordOnGetSalerCompanyResponse>>
{

    [JsonIgnore] public  string UserId { get; set; }

    public ChangePasswordOnGetSalerCompanyRequest RequestModel { get; set; }

}