using FinanceCheckUp.Application.Models.Requests.Finance.UpCrmConsole;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpCrmConsole
{
    public class FinanceUpCrmConsoleOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public FinanceUpCrmConsoleRequestInitialModel InitialModel { get; set; }
    }
}
