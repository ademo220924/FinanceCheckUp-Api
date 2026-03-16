using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancojrnl;
using FinanceCheckUp.Application.Models.Responses.dashbilancojrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancojrnl.Query.dashbilancojrnlOnGetSalerMain;
public class dashbilancojrnlOnGetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancojrnlOnGetSalerMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancojrnlOnGetSalerMainRequest Request { get; set; }

}