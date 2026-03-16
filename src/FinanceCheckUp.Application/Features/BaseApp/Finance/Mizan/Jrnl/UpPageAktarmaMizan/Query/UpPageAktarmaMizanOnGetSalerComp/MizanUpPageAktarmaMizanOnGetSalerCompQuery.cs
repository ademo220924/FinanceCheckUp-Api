using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaMizan.Query.UpPageAktarmaMizanOnGetSalerComp
{
    public class MizanUpPageAktarmaMizanOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpPageAktarmaMizanOnGetSalerCompResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpPageAktarmaMizanOnGetSalerCompRequest Request { get; set; }
        public MizanUpPageAktarmaMizanRequestInitialModel InitialModel { get; set; }
    }
}
