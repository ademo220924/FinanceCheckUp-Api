using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.DashBilancoJrnl;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.DashBilancoJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.DashBilancoJrnl.Query.DashBilancoJrnlOnGet;
public class MizanDashBilancoJrnlOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoJrnlOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanDashBilancoJrnlOnGetRequest Request { get; set; }
}