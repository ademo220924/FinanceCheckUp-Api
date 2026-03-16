using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo
{
    public class MizanDashRasyoRequestInitialModel
    {
        public long UserID;
        public long CompID;
        public int CompCount;
        public int YearCount { get; set; }
        public List<DashYearlyResultMizan> RasyoAnaliz;
        public List<DashYearlyResultMizan> OzetMali;
        public List<DashYearlyResultMizan> LikiditeRiskTrend;
        public HhvnUsers CurrentUser;
        public IEnumerable<Models.DashBoard> dash;
        public IEnumerable<DashBoardRasyo> dashrasyo; 
        public DashYearlyResultMizan RasyoAnalizView;
        public DashYearlyResultMizan OzetMaliView;
        public DashYearlyResultMizan LikiditeRiskTrendView;
        public string CompName;

        public IEnumerable<Company> mreqListCompany;
        public int StartQuestions { get; set; }
        public int AQuestions { get; set; }
        public int BQuestions { get; set; }
        public int CQuestions { get; set; }
    }
}
