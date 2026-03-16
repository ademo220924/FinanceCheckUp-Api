using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsol.Query.CompanyKonsolOnGet
{
    public class CompanyKonsolOnGetQuery : IUserIdAssignable , IRequest<GenericResult<CompanyKonsolOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public int MainID { get; set; }
        public int Id { get; set; }
    }
}