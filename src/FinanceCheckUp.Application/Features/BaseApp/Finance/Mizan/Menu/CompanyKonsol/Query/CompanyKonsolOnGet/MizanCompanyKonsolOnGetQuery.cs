using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsol;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyKonsol.Query.CompanyKonsolOnGet
{
    public class MizanCompanyKonsolOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanCompanyKonsolOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanCompanyKonsolOnGetRequest Request { get; set; }
    }
}