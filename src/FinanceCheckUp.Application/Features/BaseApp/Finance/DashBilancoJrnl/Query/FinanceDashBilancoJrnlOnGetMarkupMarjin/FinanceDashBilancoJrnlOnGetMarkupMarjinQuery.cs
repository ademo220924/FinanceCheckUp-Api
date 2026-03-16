using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashBilancoJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.DashBilancoJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashBilancoJrnl.Query.FinanceDashBilancoJrnlOnGetMarkupMarjin;
public class FinanceDashBilancoJrnlOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashBilancoJrnlOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashBilancoJrnlOnGetMarkupMarjinRequest Request { get; set; }
    public FinanceDashBilancoJrnlRequestInitialModel InitialModel { get; set; }
}
