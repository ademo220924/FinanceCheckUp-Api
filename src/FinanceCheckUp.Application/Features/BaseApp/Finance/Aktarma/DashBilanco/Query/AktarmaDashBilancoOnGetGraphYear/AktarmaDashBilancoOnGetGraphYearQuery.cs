using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashBilanco.Query.AktarmaDashBilancoOnGetGraphYear;
public class AktarmaDashBilancoOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<AktarmaDashBilancoOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public AktarmaDashBilancoOnGetGraphYearRequest Request { get; set; }

}
