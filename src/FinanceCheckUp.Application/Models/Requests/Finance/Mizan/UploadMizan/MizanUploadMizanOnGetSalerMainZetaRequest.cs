using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMizan
{
    public class MizanUploadMizanOnGetSalerMainZetaRequest
    {
        public DataSourceLoadOptions options {  get; set; }
        public int monthid { get; set; }
    }
}
