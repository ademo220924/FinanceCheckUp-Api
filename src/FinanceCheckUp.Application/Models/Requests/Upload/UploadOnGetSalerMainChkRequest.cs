using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.Upload;
public class UploadOnGetSalerMainChkRequest
{
    public DataSourceLoadOptions Options { get; set; }
    public int monthid { get; set; }
}