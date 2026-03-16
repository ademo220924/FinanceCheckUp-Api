using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaJrnl
{
    public class MizanUpPageAktarmaJrnlOnGetSalerDateCodeResponse
    {
        public JsonResult Response { get; set; }
        public MizanUpPageAktarmaJrnlRequestInitialModel InitialModel { get; set; }
    }
}
