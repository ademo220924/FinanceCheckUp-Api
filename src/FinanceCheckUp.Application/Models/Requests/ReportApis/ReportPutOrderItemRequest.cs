using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.ReportApis;

public class ReportPutOrderItemRequest : IUserIdAssignable , IRequest<GenericResult<ReportPutOrderItemResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public int Key { get; set; }
    public string Values { get; set; }
}