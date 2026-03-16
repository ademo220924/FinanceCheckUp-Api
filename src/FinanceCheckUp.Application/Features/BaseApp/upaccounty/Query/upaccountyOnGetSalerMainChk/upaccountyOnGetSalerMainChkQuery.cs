using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upaccounty;
using FinanceCheckUp.Application.Models.Responses.upaccounty;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;




namespace FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerMainChk;
public class upaccountyOnGetSalerMainChkQuery : IUserIdAssignable , IRequest<GenericResult<upaccountyOnGetSalerMainChkResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upaccountyOnGetSalerMainChkRequest Request { get; set; }

}