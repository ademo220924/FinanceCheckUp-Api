namespace FinanceCheckUp.Application.Models
{
    public class SubmissionResponse
    {
        public string requestId { get; set; }
        public string statusCode { get; set; }
        public string resultCode { get; set; }
        public string exceptionCode { get; set; }
        public string resultDescription { get; set; }
        public string expDescription { get; set; }
    }
}
