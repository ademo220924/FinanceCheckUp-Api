using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashBoard;
using FinanceCheckUp.Application.Models.Responses.DashBoard;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBoard.Query.DashBoardOnGet;
public class DashBoardOnGetQuery : IUserIdAssignable , IRequest<GenericResult<DashBoardOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashBoardOnGetRequest Request { get; set; }

}