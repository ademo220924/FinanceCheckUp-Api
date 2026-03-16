using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancomlt;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGetChartRasyo;
public class dashbilancomltOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancomltOnGetChartRasyoResponse>>
{

    public dashbilancomltOnGetChartRasyoRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancomltRequest InitialModel { get; set; }
}