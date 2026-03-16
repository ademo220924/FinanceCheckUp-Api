using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyEdit.Query.CompanyEditOnGetSalerCity
{
    public class MizanCompanyEditOnGetSalerCityQuery : IUserIdAssignable , IRequest<GenericResult<MizanCompanyEditOnGetSalerCityResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanCompanyEditOnGetSalerCityRequest Request { get; set; }
    }
}