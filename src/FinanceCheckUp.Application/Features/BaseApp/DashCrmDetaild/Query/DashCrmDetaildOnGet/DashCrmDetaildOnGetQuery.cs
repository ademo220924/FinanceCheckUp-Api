using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetaild;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaild;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaild.Query.DashCrmDetaildOnGet;
public class DashCrmDetaildOnGetQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmDetaildOnGetResponse>>
{

    [JsonIgnore] public  string UserId { get; set; }

    public DashCrmDetaildOnGetRequest Request { get; set; }
}