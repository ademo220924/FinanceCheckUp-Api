using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzan.Query.UploadMzanOnGetSalerMainChk
{
    public class MizanUploadMzanOnGetSalerMainChkQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMzanOnGetSalerMainChkResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMzanOnGetSalerMainChkRequest Request { get; set; }
        public MizanUploadMzanRequestInitialModel InitialModel { get; set; }
    }
}
