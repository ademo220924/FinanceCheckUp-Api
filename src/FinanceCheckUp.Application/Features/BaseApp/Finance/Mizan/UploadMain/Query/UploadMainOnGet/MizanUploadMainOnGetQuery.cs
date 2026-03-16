using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMain;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMain.Query.UploadMainOnGet
{
    public class MizanUploadMainOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMainOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMainOnGetRequest Request { get; set; }
    }
}
