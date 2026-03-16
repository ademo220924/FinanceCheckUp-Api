using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashRevenueJrnl;
using FinanceCheckUp.Application.Models.Responses.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetGraphComp;
public class DashRevenueJrnlOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<DashRevenueJrnlOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashRevenueJrnlOnGetGraphCompRequest Request { get; set; }

}