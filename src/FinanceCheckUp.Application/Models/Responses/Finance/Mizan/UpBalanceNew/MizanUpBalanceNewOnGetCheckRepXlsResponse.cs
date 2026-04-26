using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalanceNew;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew
{
    public class MizanUpBalanceNewOnGetCheckRepXlsResponse
    {
        /// <summary>Göreli dosya yolu (örn. FileContent/MizanRapor-....xlsx).</summary>
        public string? Response { get; set; }
        public MizanUpBalanceNewRequestInitialModel InitialModel { get; set; }
    }
}
