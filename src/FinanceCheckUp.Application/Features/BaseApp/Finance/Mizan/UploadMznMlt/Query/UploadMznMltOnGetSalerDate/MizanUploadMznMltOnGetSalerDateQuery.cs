using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznMlt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznMlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznMlt.Query.UploadMznMltOnGetSalerDate
{
    public class MizanUploadMznMltOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMznMltOnGetSalerDateResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMznMltOnGetSalerDateRequest Request { get; set; }
        public MizanUploadMznMltRequestInitialModel InitialModel { get; set; }
    }
}
