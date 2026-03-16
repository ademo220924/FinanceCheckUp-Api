using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.dashbilancomain;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.dashbilancomain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.dashbilancomain.Query.dashbilancomainOnGetMarkupMarjin;
public class AktarmaDashbilancomainOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<AktarmaDashbilancomainOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public AktarmaDashbilancomainOnGetMarkupMarjinRequest Request { get; set; }
    public AktarmaDashbilancomainInitialModel InitialModel { get; set; }

}