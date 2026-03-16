namespace FinanceCheckUp.Application.Models
{
    public class SubmissionModelT
    {
        public string vknTckn { get; set; }
        public string identityNumber { get; set; }


        public SubmissionModelT(string identityNumber_, string vknTcknr_)
        {

            identityNumber = identityNumber_;
            vknTckn = vknTcknr_;
        }
    }
}
