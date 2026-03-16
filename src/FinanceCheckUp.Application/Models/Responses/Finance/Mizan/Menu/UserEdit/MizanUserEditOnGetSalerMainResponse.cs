using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserEdit;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit
{
    public class MizanUserEditOnGetSalerMainResponse
    {
        public JsonResult Response { get; set; }
        public MizanUserEditRequestInitialModel InitialModel { get; set; }
    }
}
