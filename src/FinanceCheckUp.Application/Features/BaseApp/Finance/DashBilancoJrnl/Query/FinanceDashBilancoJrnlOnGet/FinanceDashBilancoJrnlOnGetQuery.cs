using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashBilancoJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.DashBilancoJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashBilancoJrnl.Query.FinanceDashBilancoJrnlOnGet;
public class FinanceDashBilancoJrnlOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashBilancoJrnlOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashBilancoJrnlOnGetRequest Request { get; set; }
}
