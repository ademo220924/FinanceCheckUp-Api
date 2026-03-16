using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaJrnl
{
    public class FinanceUpPageAktarmaJrnlRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public IEnumerable<DebitCreditResult> mDcResult;
        public long UserID;
        public long CompID;
        public int CompCount;
        public int YearCount;
        public long curcomID;
        public int curcomCount;
        public int Nacenum;
        public Company CurrentCom;
        public string CompName;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqListCompany;
        public string currentcompname { get; set; }
    }
}
