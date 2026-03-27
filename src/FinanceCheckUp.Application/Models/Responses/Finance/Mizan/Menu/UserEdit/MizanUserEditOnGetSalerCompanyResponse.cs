using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserEdit;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit
{
    public class MizanUserEditOnGetSalerCompanyResponse
    {
        public LoadResult Response { get; set; }
        public MizanUserEditRequestInitialModel InitialModel { get; set; }
    }
}
