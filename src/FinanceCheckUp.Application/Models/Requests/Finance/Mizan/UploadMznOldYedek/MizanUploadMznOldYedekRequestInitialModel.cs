using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznOldYedek
{
    public class MizanUploadMznOldYedekRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public long UserID;
        public long CompID;
        public int CompCount;
        public int YearCount;
        public long curcomID;
        public int curcomCount;
        public int Nacenum;

        public Company CurrentCom;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqListCompany;
        public string CompName;


        public string currentcompname { get; set; }
    }
}
