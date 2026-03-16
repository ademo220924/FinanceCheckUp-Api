using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznMlt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznMlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznMlt.Query.UploadMznMltOnGetSalerYear
{
    public class MizanUploadMznMltOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMznMltOnGetSalerYearResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMznMltOnGetSalerYearRequest Request { get; set; }
    }
}
