using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashBilanco.Query.DashBilancoOnGetMarkupMarjin;

public class MizanAktarmaDashBilancoOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<MizanAktarmaDashBilancoOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanAktarmaDashBilancoOnGetMarkupMarjinRequest Request { get; set; }
    public MizanAktarmaDashBilancoRequestInitialModel InitialModel { get; set; }
}
