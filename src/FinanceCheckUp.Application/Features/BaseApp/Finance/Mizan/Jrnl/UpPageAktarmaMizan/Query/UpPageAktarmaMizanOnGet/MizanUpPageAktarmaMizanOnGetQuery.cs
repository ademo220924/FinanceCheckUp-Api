using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using MediatR;
using FinanceCheckUp.Framework.Core.Models;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaMizan.Query.UpPageAktarmaMizanOnGet
{
    public class MizanUpPageAktarmaMizanOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpPageAktarmaMizanOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpPageAktarmaMizanOnGetRequest Request { get; set; }
    }
}
