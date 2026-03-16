using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashRevenueJrnl;
using FinanceCheckUp.Application.Models.Responses.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetPrio;
public class DashRevenueJrnlOnGetPrioQuery : IUserIdAssignable , IRequest<GenericResult<DashRevenueJrnlOnGetPrioResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashRevenueJrnlOnGetPrioRequest Request { get; set; }

}