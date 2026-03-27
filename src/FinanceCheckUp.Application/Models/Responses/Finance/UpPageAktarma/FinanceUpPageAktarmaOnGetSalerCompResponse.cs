using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarma;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarma
{
    public class FinanceUpPageAktarmaOnGetSalerCompResponse
    {
        public LoadResult Response { get; set; }
        public FinanceUpPageAktarmaRequestInitialModel InitialModel { get; set; }
    }
}
