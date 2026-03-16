using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashBilanco;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashBilanco.Query.AktarmaDashBilancoOnGet;
public class AktarmaDashBilancoOnGetQuery : IUserIdAssignable , IRequest<GenericResult<AktarmaDashBilancoOnGetResponse>>
{
    public AktarmaDashBilancoOnGetRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }

}