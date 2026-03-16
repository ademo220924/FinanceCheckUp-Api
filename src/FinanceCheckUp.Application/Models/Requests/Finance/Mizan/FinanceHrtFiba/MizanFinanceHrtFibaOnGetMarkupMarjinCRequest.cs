using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtFiba
{
    public class MizanFinanceHrtFibaOnGetMarkupMarjinCRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public long compid { get; set; }
    }
}
