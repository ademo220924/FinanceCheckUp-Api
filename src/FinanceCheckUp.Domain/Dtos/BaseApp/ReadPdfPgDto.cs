
namespace FinanceCheckUp.Domain.Dtos.BaseApp;
public class ReadPdfPgDto
{
    public string SubID { get; set; }
    public string MainID { get; set; }
    public int CounterNo { get; set; }
    public string LineContent { get; set; }
    public byte IsRevenue { get; set; }
    public byte IsGecici { get; set; }
    public byte IsEnflasyon { get; set; }
}