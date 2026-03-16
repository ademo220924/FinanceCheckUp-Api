using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upaccounty;
using FinanceCheckUp.Application.Models.Responses.upaccounty;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;




namespace FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerMainZeta;
public class upaccountyOnGetSalerMainZetaQuery : IUserIdAssignable , IRequest<GenericResult<upaccountyOnGetSalerMainZetaResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upaccountyOnGetSalerMainZetaRequest Request { get; set; }

}