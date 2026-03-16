using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaMizan.Query.UpPageAktarmaMizanOnGetSalerYear
{
    public class MizanUpPageAktarmaMizanOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpPageAktarmaMizanOnGetSalerYearResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpPageAktarmaMizanOnGetSalerYearRequest Request { get; set; }
    }
}
