using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashBilanco.Query.DashBilancoOnGet;

public class MizanAktarmaDashBilancoOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanAktarmaDashBilancoOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanAktarmaDashBilancoOnGetRequest Request { get; set; }
}
