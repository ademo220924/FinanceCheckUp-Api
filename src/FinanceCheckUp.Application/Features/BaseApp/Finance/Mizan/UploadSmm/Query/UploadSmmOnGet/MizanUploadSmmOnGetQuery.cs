using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadSmm;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadSmm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadSmm.Query.UploadSmmOnGet
{
    public class MizanUploadSmmOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadSmmOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadSmmOnGetRequest Request { get; set; }
    }
}
