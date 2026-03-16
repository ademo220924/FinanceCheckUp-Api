using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMain;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMain.Query.UploadMainOnGetSalerMainZeta
{
    public class MizanUploadMainOnGetSalerMainZetaQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMainOnGetSalerMainZetaResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMainOnGetSalerMainZetaRequest Request { get; set; }
        public MizanUploadMainRequestInitialModel InitialModel { get; set; }
    }
}
