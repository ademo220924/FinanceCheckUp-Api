
using FinanceCheckUp.Application.Models.Requests.DashRevenueJrnl;

namespace FinanceCheckUp.Application.Models.Responses.DashRevenueJrnl;
public class DashRevenueJrnlOnGetResponse
{
    public string Response { get; set; }
    public DashRevenueJrnlRequest InitialModel { get; set; }
}