using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpPageAktarma.Query.UpPageAktarmaOnGetSalerYear
{
    public class MizanUpPageAktarmaOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpPageAktarmaOnGetSalerYearResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpPageAktarmaOnGetSalerYearRequest Request { get; set; }
    }
}
