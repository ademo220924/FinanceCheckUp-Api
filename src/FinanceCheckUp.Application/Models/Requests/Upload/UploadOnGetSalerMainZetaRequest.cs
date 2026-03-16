using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.Upload;
public class UploadOnGetSalerMainZetaRequest
{
    public DataSourceLoadOptions Options { get; set; }
    public int monthid { get; set; }
}