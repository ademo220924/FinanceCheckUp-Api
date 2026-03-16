using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashBoard;
using FinanceCheckUp.Application.Models.Responses.DashBoard;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBoard.Query.DashBoardOnGetGraphYear;
public class DashBoardOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<DashBoardOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashBoardOnGetGraphYearRequest Request { get; set; }

}