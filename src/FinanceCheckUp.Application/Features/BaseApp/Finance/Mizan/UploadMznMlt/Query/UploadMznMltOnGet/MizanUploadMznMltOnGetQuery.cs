using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznMlt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznMlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznMlt.Query.UploadMznMltOnGet
{
    public class MizanUploadMznMltOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMznMltOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMznMltOnGetRequest Request { get; set; }
    }
}
