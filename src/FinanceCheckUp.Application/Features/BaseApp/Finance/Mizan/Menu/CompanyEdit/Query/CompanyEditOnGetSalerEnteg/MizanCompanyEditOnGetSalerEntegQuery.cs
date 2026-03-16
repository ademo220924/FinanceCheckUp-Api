using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyEdit.Query.CompanyEditOnGetSalerEnteg
{
    public class MizanCompanyEditOnGetSalerEntegQuery : IUserIdAssignable , IRequest<GenericResult<MizanCompanyEditOnGetSalerEntegResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanCompanyEditOnGetSalerEntegRequest Request { get; set; }
    }
}

