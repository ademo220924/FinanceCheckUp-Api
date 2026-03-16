using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadSmm;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadSmm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadSmm.Query.UploadSmmOnGetSalerYear
{
    public class MizanUploadSmmOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadSmmOnGetSalerYearResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadSmmOnGetSalerYearRequest Request { get; set; }
    }
}
