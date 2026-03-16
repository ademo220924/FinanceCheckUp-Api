using FinanceCheckUp.Application.Models.Common;

namespace FinanceCheckUp.Application.Models.Requests;

public class NotificationSendMailRequest
{
    public SendMailRequest SendMailRequest { get; set; }
}