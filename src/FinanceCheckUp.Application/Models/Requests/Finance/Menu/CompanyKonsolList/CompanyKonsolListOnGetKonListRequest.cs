using DevExtreme.AspNet.Mvc;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyKonsolList
{
    public class CompanyKonsolListOnGetKonListRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public long ide {  get; set; }
    }
}