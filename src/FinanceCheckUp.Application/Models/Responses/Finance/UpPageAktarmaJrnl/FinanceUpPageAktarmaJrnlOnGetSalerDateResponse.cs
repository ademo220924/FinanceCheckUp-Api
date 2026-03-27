using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaJrnl;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl
{
    public class FinanceUpPageAktarmaJrnlOnGetSalerDateResponse
    {
        public LoadResult Response { get; set; }
        public FinanceUpPageAktarmaJrnlRequestInitialModel InitialModel { get; set; }
    }
}
