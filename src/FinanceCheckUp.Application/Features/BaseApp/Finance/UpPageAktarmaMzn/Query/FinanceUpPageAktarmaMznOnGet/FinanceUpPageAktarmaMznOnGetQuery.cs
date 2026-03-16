using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaMzn;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaMzn.Query.FinanceUpPageAktarmaMznOnGet;
public class FinanceUpPageAktarmaMznOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpPageAktarmaMznOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpPageAktarmaMznOnGetRequest Request { get; set; }
}
