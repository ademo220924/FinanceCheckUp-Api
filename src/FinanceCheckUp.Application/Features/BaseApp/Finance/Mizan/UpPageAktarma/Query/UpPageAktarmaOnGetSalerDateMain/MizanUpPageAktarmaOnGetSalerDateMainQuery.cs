using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpPageAktarma.Query.UpPageAktarmaOnGetSalerDateMain
{
    public class MizanUpPageAktarmaOnGetSalerDateMainQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpPageAktarmaOnGetSalerDateMainResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpPageAktarmaOnGetSalerDateMainRequest Request { get; set; }
        public MizanUpPageAktarmaRequestInitialModel InitialModel { get; set; }
    }
}
