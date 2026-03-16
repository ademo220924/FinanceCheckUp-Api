using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashBilanco.Query.AktarmaDashBilancoOnGetMarkupMarjin;
public class AktarmaDashBilancoOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<AktarmaDashBilancoOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public AktarmaDashBilancoOnGetMarkupMarjinRequest Request { get; set; }
    public AktarmaDashBilancoInitialModel InitialModel { get; set; }

}

