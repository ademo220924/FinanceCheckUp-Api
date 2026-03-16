using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilsample;
using FinanceCheckUp.Application.Models.Responses.dashbilsample;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilsample.Query.dashbilsampleOnGetGraphYear;
public class dashbilsampleOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<dashbilsampleOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilsampleOnGetGraphYearRequest Request { get; set; }

}