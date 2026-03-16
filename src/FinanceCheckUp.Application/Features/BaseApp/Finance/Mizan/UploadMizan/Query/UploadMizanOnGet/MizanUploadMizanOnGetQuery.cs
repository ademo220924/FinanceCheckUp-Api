using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMizan.Query.UploadMizanOnGet
{
    public class MizanUploadMizanOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMizanOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMizanOnGetRequest Request { get; set; }
    }
}
