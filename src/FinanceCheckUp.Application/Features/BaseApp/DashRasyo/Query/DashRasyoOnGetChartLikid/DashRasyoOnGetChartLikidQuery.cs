using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetChartLikid;
public class DashRasyoOnGetChartLikidQuery : IUserIdAssignable , IRequest<GenericResult<DashRasyoOnGetChartLikidResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashRasyoOnGetChartLikidRequest Request { get; set; }

}