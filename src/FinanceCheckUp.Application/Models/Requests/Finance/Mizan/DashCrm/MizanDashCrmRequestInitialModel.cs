using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashCrm
{
    public class MizanDashCrmRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public long UserID;
        public long CompID;
        public int CompCount;
        public int YearCount;
        public string CompName;
        public List<DashYearlyResultCRMMain> RasyoAnalizCRM;
        public List<DashYearlyResult> OzetMali;
        public List<DashYearlyResult> LikiditeRiskTrend;
        public HhvnUsers CurrentUser;
        public IEnumerable<Models.DashBoard> dash;
        public IEnumerable<DashBoardRasyo> dashrasyo;
        public DashYearlyResultChart RasyoAnalizView;
        public DashYearlyResultChartCRM RasyoAnalizViewCrm;
        public DashYearlyResultChart OzetMaliView;
        public DashYearlyResultChart LikiditeRiskTrendView;

        public IEnumerable<Company> mreqListCompany;
        public int StartQuestions { get; set; }
        public int AQuestions { get; set; }
        public int BQuestions { get; set; }
        public int CQuestions { get; set; }

        /// <summary>Pivot verisi — CRMAnalizTOTAL102Mizan (Banka ilk 10).</summary>
        public List<DashYearlyResultCRM> CrmPivot102Rows { get; set; }

        /// <summary>Pivot verisi — CRMAnalizTOTAL103Mizan (Verilen çek).</summary>
        public List<DashYearlyResultCRM> CrmPivot103Rows { get; set; }

        /// <summary>Pivot verisi — CRMAnalizTOTAL101Mizan (Alınan çek).</summary>
        public List<DashYearlyResultCRM> CrmPivot101Rows { get; set; }

        /// <summary>Pivot verisi — CRMAnalizTOTAL120Mizan (Alıcılar).</summary>
        public List<DashYearlyResultCRM> CrmPivot120Rows { get; set; }
    }
}
