using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMizan
{
    public class MizanUploadMizanOnGetSalerMainChkRequest
    {
        public DataSourceLoadOptions options {  get; set; }
        public int monthid { get; set; }
    }
}
