using FinanceCheckUp.Application.Models.Requests.Finance.UpReportMain;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain
{
    public class FinanceUpReportMainOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public FinanceUpReportMainRequestInitialModel InitialModel { get; set; }
    }
}
