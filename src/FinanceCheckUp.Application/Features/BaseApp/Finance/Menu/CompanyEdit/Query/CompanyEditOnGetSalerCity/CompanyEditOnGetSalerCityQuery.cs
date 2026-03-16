using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyEdit.Query.CompanyEditOnGetSalerCity
{
    public class CompanyEditOnGetSalerCityQuery : IUserIdAssignable , IRequest<GenericResult<CompanyEditOnGetSalerCityResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public CompanyEditOnGetSalerCityRequest Request { get; set; }
    }
}