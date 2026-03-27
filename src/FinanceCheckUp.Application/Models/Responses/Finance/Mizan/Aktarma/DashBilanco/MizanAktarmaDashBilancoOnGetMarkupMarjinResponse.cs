using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashBilanco;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashBilanco
{
    public class MizanAktarmaDashBilancoOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public MizanAktarmaDashBilancoRequestInitialModel InitialModel { get; set; }
    }
}
