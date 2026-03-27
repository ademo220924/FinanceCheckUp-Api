using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaMzn;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaMzn
{
    public class FinanceUpPageAktarmaMznOnGetSalerCompResponse
    {
        public LoadResult Response { get; set; }
        public FinanceUpPageAktarmaMznRequestInitialModel InitialModel { get; set; }
    }
}
