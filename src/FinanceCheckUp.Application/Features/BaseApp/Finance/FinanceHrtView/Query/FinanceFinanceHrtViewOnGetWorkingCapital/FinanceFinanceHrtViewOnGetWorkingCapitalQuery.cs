using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtView;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtView.Query.FinanceFinanceHrtViewOnGetWorkingCapital;
public class FinanceFinanceHrtViewOnGetWorkingCapitalQuery : IUserIdAssignable , IRequest<GenericResult<FinanceFinanceHrtViewOnGetWorkingCapitalResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceFinanceHrtViewOnGetWorkingCapitalRequest Request { get; set; }
    public FinanceFinanceHrtViewRequestInitialModel InitialModel { get; set; }
}
