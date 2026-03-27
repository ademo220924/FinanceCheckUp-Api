using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashCompare;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashCompare
{
    public class MizanAktarmaDashCompareOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public MizanAktarmaDashCompareRequestInitialModel InitialModel { get; set; }
    }
}
