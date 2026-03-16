namespace FinanceCheckUp.Application.Models
{
    public class SubmissionModel
    {
        public string identityNumber { get; set; }


        public SubmissionModel(string identityNumber_)
        {

            identityNumber = identityNumber_;
        }
    }
}
