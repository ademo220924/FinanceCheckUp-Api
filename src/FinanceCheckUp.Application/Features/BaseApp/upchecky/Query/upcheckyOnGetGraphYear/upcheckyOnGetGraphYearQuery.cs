using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upchecky;
using FinanceCheckUp.Application.Models.Responses.upchecky;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upchecky.Query.upcheckyOnGetGraphYear;
public class upcheckyOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<upcheckyOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upcheckyOnGetGraphYearRequest Request { get; set; }

}