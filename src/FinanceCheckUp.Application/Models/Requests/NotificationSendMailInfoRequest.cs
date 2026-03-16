using FinanceCheckUp.Application.Models.Common;

namespace FinanceCheckUp.Application.Models.Requests;

public class NotificationSendMailInfoRequest
{
    public SendMailRequest SendMailRequest { get; set; }
}