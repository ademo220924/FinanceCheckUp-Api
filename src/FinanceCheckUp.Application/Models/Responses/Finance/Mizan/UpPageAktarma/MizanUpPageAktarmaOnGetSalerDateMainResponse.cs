using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpPageAktarma;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpPageAktarma
{
    public class MizanUpPageAktarmaOnGetSalerDateMainResponse
    {
        public LoadResult Response { get; set; }
        public MizanUpPageAktarmaRequestInitialModel InitialModel { get; set; }
    }
}
