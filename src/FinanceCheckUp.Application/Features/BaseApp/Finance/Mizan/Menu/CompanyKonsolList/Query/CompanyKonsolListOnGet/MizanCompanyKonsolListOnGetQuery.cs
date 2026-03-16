using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsolList;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsolList;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyKonsolList.Query.CompanyKonsolListOnGet
{
    public class MizanCompanyKonsolListOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanCompanyKonsolListOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanCompanyKonsolListOnGetRequest Request { get; set; }
    }
}