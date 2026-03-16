using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyList;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyList;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyList.Query.CompanyListOnGet
{
    public class MizanCompanyListOnGetQuery : IRequest<GenericResult<MizanCompanyListOnGetResponse>>,IUserIdAssignable
    {
     
        public MizanCompanyListOnGetRequest Request { get; set; }
        public string UserId { get; set; }
    }
}
