using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoMlt;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoMlt
{
    public class MizanDashBilancoMltOnGetChartRasyoResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashBilancoMltRequestInitialModel InitialModel { get; set; }
    }
}
