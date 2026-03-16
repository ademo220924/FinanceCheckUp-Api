using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGetChartRasyo;
public class DashBilancoOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<DashBilancoOnGetChartRasyoResponse>>
{

    public DashBilancoOnGetChartRasyoRequest RequestModel { get; set; }
    [JsonIgnore] public  string UserId { get; set; }


}