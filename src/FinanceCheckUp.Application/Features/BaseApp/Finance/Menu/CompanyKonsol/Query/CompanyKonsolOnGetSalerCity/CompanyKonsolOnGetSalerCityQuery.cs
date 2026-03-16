using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyKonsol;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsol.Query.CompanyKonsolOnGetSalerCity
{
    public class CompanyKonsolOnGetSalerCityQuery : IUserIdAssignable , IRequest<GenericResult<CompanyKonsolOnGetSalerCityResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public CompanyKonsolOnGetSalerCityRequest Request { get; set; }
    }
}
