using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.UpReportMain
{
    public class FinanceUpReportMainRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public long UserID;
        public long CompID;
        public int CompCount;
        public string CompName;
        public int YearCount;
        public long curcomID;
        public int curcomCount;
        public HhvnUsers CurrentUser;
        public int YearCurrent; 
        public IEnumerable<Company> mreqListCompany;
        public Company curCompany;
        public int nyear;
        public long companyID;
        public string currentcompname { get; set; }
        public string FilePath { get; set; }
    }
}
