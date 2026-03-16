using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashBilanco.Query.AktarmaDashBilancoOnGetAktarmaResult;
public class AktarmaDashBilancoOnGetAktarmaResultQuery : IUserIdAssignable , IRequest<GenericResult<AktarmaDashBilancoOnGetAktarmaResultResponse>>
{

    [JsonIgnore] public  string UserId { get; set; }
    public AktarmaDashBilancoOnGetAktarmaResultRequest Request { get; set; }
    public AktarmaDashBilancoInitialModel InitialModel { get; set; }

}
