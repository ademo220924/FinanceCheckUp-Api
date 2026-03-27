using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.CashFlow;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.CashFlow
{
    public class MizanCashFlowOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public MizanCashFlowRequestInitialModel InitialModel { get; set; }
    }
}
