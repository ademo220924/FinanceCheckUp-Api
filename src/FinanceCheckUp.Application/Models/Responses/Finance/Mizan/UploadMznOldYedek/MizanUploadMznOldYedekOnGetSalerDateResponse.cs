using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznOldYedek;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznOldYedek
{
    public class MizanUploadMznOldYedekOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public MizanUploadMznOldYedekRequestInitialModel InitialModel { get; set; }
    }
}
