using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzan.Query.UploadMzanOnGetSalerMainZeta
{
    public class MizanUploadMzanOnGetSalerMainZetaQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMzanOnGetSalerMainZetaResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMzanOnGetSalerMainZetaRequest Request { get; set; }
        public MizanUploadMzanRequestInitialModel InitialModel { get; set; }
    }
}
