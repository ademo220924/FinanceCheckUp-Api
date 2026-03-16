using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.DashBilancoJrnl;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.DashBilancoJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.DashBilancoJrnl.Query.DashBilancoJrnlOnGetMarkupMarjin;
public class MizanDashBilancoJrnlOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoJrnlOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanDashBilancoJrnlOnGetMarkupMarjinRequest Request { get; set; }
    public MizanDashBilancoJrnlRequestInitialModel InitialModel { get; set; }
}