using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzan
{
    public class MizanUploadMzanOnGetSalerMainChkRequest
    {
        public DataSourceLoadOptions options {  get; set; }
        public int monthid { get; set; }
    }
}
