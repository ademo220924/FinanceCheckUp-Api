using FinanceCheckUp.Application.Models.Requests.Finance.DashCrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashCrm
{
    public class FinanceDashCrmOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public FinanceDashCrmRequestInitialModel InitialModel { get; set; }
    }
}
