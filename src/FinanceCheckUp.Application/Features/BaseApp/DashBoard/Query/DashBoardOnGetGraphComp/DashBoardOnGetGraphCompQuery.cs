using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashBoard;
using FinanceCheckUp.Application.Models.Responses.DashBoard;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBoard.Query.DashBoardOnGetGraphComp;
public class DashBoardOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<DashBoardOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashBoardOnGetGraphCompRequest Request { get; set; }

}