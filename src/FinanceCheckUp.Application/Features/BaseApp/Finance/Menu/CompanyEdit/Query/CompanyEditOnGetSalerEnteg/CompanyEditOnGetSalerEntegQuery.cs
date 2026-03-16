using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyEdit.Query.CompanyEditOnGetSalerEnteg
{
    public class CompanyEditOnGetSalerEntegQuery : IUserIdAssignable , IRequest<GenericResult<CompanyEditOnGetSalerEntegResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public CompanyEditOnGetSalerEntegRequest Request { get; set; }
    }
}

