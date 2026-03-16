using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinancesHrtfibapr
{
    public class MizanFinancesHrtfibaprOnGetMarkupMarjinBRequest
    {
        public DataSourceLoadOptions options {  get; set; }
        public long compid {  get; set; }
    }
}
