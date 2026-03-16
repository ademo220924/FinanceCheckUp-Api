using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsolList;

public class MizanCompanyKonsolListOnGetKonListRequest
{
    public DataSourceLoadOptions options {  get; set; }
    public long ide {  get; set; }
}
