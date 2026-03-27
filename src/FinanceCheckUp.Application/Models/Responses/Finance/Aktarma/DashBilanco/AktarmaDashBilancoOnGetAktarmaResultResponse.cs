using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashBilanco;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
public class AktarmaDashBilancoOnGetAktarmaResultResponse
{
    public LoadResult Response { get; set; }
    public AktarmaDashBilancoInitialModel InitialModel { get; set; }
}
