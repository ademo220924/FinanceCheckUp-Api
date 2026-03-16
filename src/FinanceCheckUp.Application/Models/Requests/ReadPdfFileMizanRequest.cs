namespace FinanceCheckUp.Application.Models.Requests
{
    public class ReadPdfFileMizanRequest
    {
        public long compid { get; set; }
        public int nyear { get; set; }
        public byte nmonth { get; set; }
    }
}
