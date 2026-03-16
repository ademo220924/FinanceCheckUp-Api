using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznOldYedek.Query.UploadMznOldYedekOnGetSalerDate
{
    public class MizanUploadMznOldYedekOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMznOldYedekOnGetSalerDateResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMznOldYedekOnGetSalerDateRequest Request { get; set; }
        public MizanUploadMznOldYedekRequestInitialModel InitialModel { get; set; }
    }
}
