using FinanceCheckUp.Application.Models.Requests.Finance.Menu.UserEdit;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Menu.UserEdit
{
    public class UserEditOnGetSalerCompanyResponse
    {
        public LoadResult Response { get; set; }
        public UserEditInitialModel InitialModel { get; set; }
    }
}
