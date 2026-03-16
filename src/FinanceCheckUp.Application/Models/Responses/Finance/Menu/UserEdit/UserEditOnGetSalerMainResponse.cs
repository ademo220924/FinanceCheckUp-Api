using FinanceCheckUp.Application.Models.Requests.Finance.Menu.UserEdit;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Menu.UserEdit
{
    public class UserEditOnGetSalerMainResponse
    {
        public JsonResult Response { get; set; }
        public UserEditInitialModel InitialModel { get; set; }
    }
}
