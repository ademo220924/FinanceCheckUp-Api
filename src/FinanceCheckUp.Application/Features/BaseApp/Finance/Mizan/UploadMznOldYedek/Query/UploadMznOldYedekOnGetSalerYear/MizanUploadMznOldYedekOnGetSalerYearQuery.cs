using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznOldYedek.Query.UploadMznOldYedekOnGetSalerYear
{
    public class MizanUploadMznOldYedekOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<MizanUploadMznOldYedekOnGetSalerYearResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUploadMznOldYedekOnGetSalerYearRequest Request { get; set; }
    }
}
