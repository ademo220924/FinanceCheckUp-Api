using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznOldYedek;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznOldYedek
{
    public class MizanUploadMznOldYedekOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public MizanUploadMznOldYedekRequestInitialModel InitialModel { get; set; }
    }
}
