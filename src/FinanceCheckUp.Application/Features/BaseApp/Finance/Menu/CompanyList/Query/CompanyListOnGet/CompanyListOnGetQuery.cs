using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyList;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyList;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyList.Query.CompanyListOnGet
{
    public class CompanyListOnGetQuery : IUserIdAssignable , IRequest<GenericResult<CompanyListOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public CompanyListOnGetRequest Request { get; set; }
    }
}
