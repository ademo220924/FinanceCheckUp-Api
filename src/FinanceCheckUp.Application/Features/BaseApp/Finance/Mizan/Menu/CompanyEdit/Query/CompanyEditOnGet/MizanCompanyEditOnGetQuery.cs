using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyEdit.Query.CompanyEditOnGet
{
    public class MizanCompanyEditOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanCompanyEditOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanCompanyEditOnGetRequest Request { get; set; }
    }
}
