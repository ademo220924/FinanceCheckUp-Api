using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.dashbilancomain;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.dashbilancomain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.dashbilancomain.Query.dashbilancomainOnGet;
public class AktarmaDashbilancomainOnGetQuery : IUserIdAssignable , IRequest<GenericResult<AktarmaDashbilancomainOnGetResponse>>
{
    public AktarmaDashbilancomainOnGetRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }

}
