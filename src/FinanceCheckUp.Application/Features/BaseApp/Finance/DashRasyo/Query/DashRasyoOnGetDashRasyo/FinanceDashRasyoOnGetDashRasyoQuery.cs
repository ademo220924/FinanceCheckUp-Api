using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRasyo.Query.DashRasyoOnGetDashRasyo;
public class FinanceDashRasyoOnGetDashRasyoQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashRasyoOnGetDashRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashRasyoOnGetDashRasyoRequest Request { get; set; }
    public FinanceDashRasyoRequestInitialModel InitialModel { get; set; }
}
