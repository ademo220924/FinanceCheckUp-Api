using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzn;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzn.Query.UploadMznOnGetSalerMainChk
{
    public class MizanUploadMznOnGetSalerMainChkQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMznOnGetSalerMainChkResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMznOnGetSalerMainChkRequest Request { get; set; }
        public MizanUploadMznRequestInitialModel InitialModel { get; set; }
    }
}
