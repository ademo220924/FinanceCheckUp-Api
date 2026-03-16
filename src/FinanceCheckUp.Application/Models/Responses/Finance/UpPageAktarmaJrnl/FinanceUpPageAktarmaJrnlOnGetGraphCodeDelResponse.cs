using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaJrnl;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl
{
    public class FinanceUpPageAktarmaJrnlOnGetGraphCodeDelResponse
    {
        public JsonResult Response { get; set; }
        public FinanceUpPageAktarmaJrnlRequestInitialModel InitialModel { get; set; }
    }
}
