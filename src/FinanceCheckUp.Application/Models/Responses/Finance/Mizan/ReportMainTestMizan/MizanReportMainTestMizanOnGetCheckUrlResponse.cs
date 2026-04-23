namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan
{
    public class MizanReportMainTestMizanOnGetCheckUrlResponse
    {
        /// <summary>
        /// PublicFileHostingSettings:BaseUrl doluysa mutlak URL; değilse göreli FileContent/... yolu.
        /// </summary>
        public string FileUrl { get; set; } = "";
    }
}
