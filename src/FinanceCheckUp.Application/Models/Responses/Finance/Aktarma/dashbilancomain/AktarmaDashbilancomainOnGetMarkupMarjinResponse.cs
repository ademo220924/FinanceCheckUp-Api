using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.dashbilancomain;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.dashbilancomain;
public class AktarmaDashbilancomainOnGetMarkupMarjinResponse
{
    public AktarmaDashbilancomainInitialModel InitialModel { get; set; }
    public LoadResult Result { get; set; }
}
