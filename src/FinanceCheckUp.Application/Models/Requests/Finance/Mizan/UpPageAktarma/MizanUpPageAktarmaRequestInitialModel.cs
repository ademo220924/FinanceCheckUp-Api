using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpPageAktarma
{
    public class MizanUpPageAktarmaRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult{ get; set; }
        public long UserID{ get; set; }
        public long CompID{ get; set; }
        public int CompCount{ get; set; }
        public int YearCount{ get; set; }
        public long curcomID{ get; set; }
        public int curcomCount{ get; set; }
        public int Nacenum{ get; set; }
        public Company CurrentCom{ get; set; }
        public HhvnUsers CurrentUser{ get; set; }
        public string CompName{ get; set; }
        public IEnumerable<Company> mreqListCompany{ get; set; }
        public string currentcompname { get; set; }
    }
}
