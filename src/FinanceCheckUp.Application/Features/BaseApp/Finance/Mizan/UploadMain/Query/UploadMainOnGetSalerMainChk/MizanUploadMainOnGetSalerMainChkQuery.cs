using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMain;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMain.Query.UploadMainOnGetSalerMainChk
{
    public class MizanUploadMainOnGetSalerMainChkQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMainOnGetSalerMainChkResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMainOnGetSalerMainChkRequest Request { get; set; }
        public MizanUploadMainRequestInitialModel InitialModel { get; set; }
    }
}
