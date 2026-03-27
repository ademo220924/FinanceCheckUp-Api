using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpCrmConsole;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpCrmConsole
{
    public class MizanUpCrmConsoleOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public MizanUpCrmConsoleRequestInitialModel InitialModel { get; set; }
    }
}
