using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancojrnl;
using FinanceCheckUp.Application.Models.Responses.dashbilancojrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancojrnl.Query.dashbilancojrnlOnGetGraphYear;
public class dashbilancojrnlOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancojrnlOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancojrnlGetGraphYearRequest Request { get; set; }

}