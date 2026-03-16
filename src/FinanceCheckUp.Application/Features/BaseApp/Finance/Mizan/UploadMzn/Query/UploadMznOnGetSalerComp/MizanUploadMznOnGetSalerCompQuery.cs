using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzn;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzn.Query.UploadMznOnGetSalerComp
{
    public class MizanUploadMznOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMznOnGetSalerCompResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMznOnGetSalerCompRequest Request { get; set; }
    }
}
