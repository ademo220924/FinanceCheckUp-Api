using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsol;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsol
{
    public class MizanCompanyKonsolOnGetSalerEntegResponse
    {
        public LoadResult Response { get; set; }
        public MizanCompanyKonsolRequestInitialModel InitialModel { get; set; }
    }
}
