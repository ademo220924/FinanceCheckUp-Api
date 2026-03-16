using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyKonsol
{
    public class CompanyKonsolInitialModel
    {
        public Company mrequest;
        public Company mrequestmain;
        public int StartQuestions { get; set; }
        public int AQuestions { get; set; }
        public int BQuestions { get; set; }
        public int CQuestions { get; set; }
    }
}
