using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzn
{
    public class MizanUploadMznOnGetSalerMainChkRequest
    {
        public DataSourceLoadOptions options {  get; set; }
        public int monthid { get; set; }
    }
}
