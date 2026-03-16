using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Notification.Command.SendMailInfo;

public class SendMailInfoCommand : IRequest<GenericResult<NotificationSendMailResponse>>
{
    public SendMailRequest SendMailInfoRequest { get; set; }
}