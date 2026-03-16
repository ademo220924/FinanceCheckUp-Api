namespace FinanceCheckUp.Application.Models
{
    public class GetTokenResponse
    {
        public string requestId { get; set; }
        public string statusCode { get; set; }
        public string resultCode { get; set; }
        public string exceptionCode { get; set; }
        public string resultDescription { get; set; }
        public string expDescription { get; set; }
        public string accessToken { get; set; }
    }
}
