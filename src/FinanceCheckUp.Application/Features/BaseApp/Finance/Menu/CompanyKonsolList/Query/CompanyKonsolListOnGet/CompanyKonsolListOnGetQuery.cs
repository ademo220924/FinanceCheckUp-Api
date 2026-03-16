using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyKonsolList;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyKonsolList;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsolList.Query.CompanyKonsolListOnGet
{
    public class CompanyKonsolListOnGetQuery : IUserIdAssignable , IRequest<GenericResult<CompanyKonsolListOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public CompanyKonsolListOnGetRequest Request { get; set; }
    }
}