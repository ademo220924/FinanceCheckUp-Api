using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsol;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyKonsol.Query.CompanyKonsolOnGetSalerCity
{
    public class MizanCompanyKonsolOnGetSalerCityQuery : IUserIdAssignable , IRequest<GenericResult<MizanCompanyKonsolOnGetSalerCityResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanCompanyKonsolOnGetSalerCityRequest Request { get; set; }
    }
}
