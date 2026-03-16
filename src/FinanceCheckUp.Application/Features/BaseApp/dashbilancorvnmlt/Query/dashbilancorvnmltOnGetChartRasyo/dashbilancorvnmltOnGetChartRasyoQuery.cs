using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnmlt;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmlt.Query.dashbilancorvnmltOnGetChartRasyo;
public class dashbilancorvnmltOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancorvnmltOnGetChartRasyoResponse>>
{

    public dashbilancorvnmltOnGetChartRasyoRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancorvnmltRequest InitialModel { get; set; }
}