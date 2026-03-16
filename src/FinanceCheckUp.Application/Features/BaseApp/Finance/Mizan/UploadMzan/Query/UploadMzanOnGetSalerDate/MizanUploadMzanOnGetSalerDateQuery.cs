using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzan.Query.UploadMzanOnGetSalerDate
{
    public class MizanUploadMzanOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMzanOnGetSalerDateResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMzanOnGetSalerDateRequest Request { get; set; }
        public MizanUploadMzanRequestInitialModel InitialModel { get; set; }
    }
}
