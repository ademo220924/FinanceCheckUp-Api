using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashBilancoKon;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashBilancoKon
{
    public class MizanDashBilancoKonOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashBilancoKonRequestInitialModel InitialModel { get; set; }
    }
}
