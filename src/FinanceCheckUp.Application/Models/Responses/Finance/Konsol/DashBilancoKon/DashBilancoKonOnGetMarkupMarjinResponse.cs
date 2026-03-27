using FinanceCheckUp.Application.Models.Requests.Finance.Konsol.DashBilancoKon;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashBilancoKon
{
    public class DashBilancoKonOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public DashBilancoKonInitialModel InitialModel { get; set; }
    }
}
