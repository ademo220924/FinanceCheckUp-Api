using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upaccount;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetCheckRepPdf;
public class upaccountOnGetCheckRepPdfQuery : IUserIdAssignable , IRequest<GenericResult<upaccountOnGetCheckRepPdfResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upaccountOnGetCheckRepPdfRequest Request { get; set; }

}