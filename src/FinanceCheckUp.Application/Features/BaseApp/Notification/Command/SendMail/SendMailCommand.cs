using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Notification.Command.SendMail;

public class SendMailCommand : IRequest<GenericResult<NotificationSendMailResponse>>
{
    public SendMailRequest SendMailRequest { get; set; }
}