using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyKonsol;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsol.Query.CompanyKonsolOnGetSalerEnteg
{
    public class CompanyKonsolOnGetSalerEntegQuery : IUserIdAssignable , IRequest<GenericResult<CompanyKonsolOnGetSalerEntegResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public CompanyKonsolOnGetSalerEntegRequest Request { get; set; }
    }
}
