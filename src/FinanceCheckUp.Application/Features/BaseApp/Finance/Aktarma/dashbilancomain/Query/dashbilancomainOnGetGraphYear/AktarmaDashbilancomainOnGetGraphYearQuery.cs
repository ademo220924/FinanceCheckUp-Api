using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.dashbilancomain;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.dashbilancomain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.dashbilancomain.Query.dashbilancomainOnGetGraphYear;
public class AktarmaDashbilancomainOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<AktarmaDashbilancomainOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public AktarmaDashbilancomainOnGetGraphYearRequest Request { get; set; }

}
