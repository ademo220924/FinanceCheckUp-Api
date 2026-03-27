using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilanco;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilanco
{
    public class MizanDashBilancoOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashBilancoRequestInitialModel InitialModel { get; set; }
    }
}
