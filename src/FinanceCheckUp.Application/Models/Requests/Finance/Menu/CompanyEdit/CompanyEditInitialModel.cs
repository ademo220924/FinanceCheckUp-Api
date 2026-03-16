using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyEdit
{
    public class CompanyEditInitialModel
    {
        public long UserID;
        public HhvnUsers CurrentUser;
        public Company mrequest;

        public int StartQuestions { get; set; }
        public int AQuestions { get; set; }
        public int BQuestions { get; set; }
        public int CQuestions { get; set; }
    }
}