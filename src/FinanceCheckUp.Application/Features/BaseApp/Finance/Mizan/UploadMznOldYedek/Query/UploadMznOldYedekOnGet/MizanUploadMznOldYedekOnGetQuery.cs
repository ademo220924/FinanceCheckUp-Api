using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznOldYedek.Query.UploadMznOldYedekOnGet
{
    public class MizanUploadMznOldYedekOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMznOldYedekOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMznOldYedekOnGetRequest Request { get; set; }
    }
}
