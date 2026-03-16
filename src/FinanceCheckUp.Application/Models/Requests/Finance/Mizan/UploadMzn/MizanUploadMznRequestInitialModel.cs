using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzn
{
    public class MizanUploadMznRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public long UserID;
        public long CompID;
        public int CompCount;
        public int YearCount;
        public long curcomID;
        public int curcomCount;
        public DataViewerMain mrequestDataViewer;
        public HhvnUsers CurrentUser;
        public List<YearlyErrorResult> currentUploadM;
        public List<int> currentUploadYear;


        public IEnumerable<Company> mreqListCompany;
        public Company currenCompanie;
        public string CompName;


        public string currentcompname { get; set; }
    }
}
