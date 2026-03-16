using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace FinanceCheckUp.Application.Features.BaseApp.Notification.Command.SendMail;

public class SendMailCommandHandle(IOptions<SmtpSettings> smtpSettings) : IRequestHandler<SendMailCommand, GenericResult<NotificationSendMailResponse>>
{
    private readonly SmtpSettings _smtpSettings = smtpSettings.Value;

    public Task<GenericResult<NotificationSendMailResponse>> Handle(SendMailCommand request, CancellationToken cancellationToken)
    {
        using var client = new SmtpClient();
        client.Host = _smtpSettings.Host;
        client.Port = _smtpSettings.Port;
        client.UseDefaultCredentials = false;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.Credentials = new NetworkCredential(_smtpSettings.NetworkCredentialUserName, _smtpSettings.NetworkCredentialPassword);
        client.TargetName = _smtpSettings.TargetName;
        client.EnableSsl = true;
        var message = new MailMessage
        {
            From = new MailAddress(_smtpSettings.NetworkCredentialUserName),
            Subject = " Bilgilendirme site üzerinden bir teklif talebi geldi- fincheckup.ai",
            IsBodyHtml = true,
            Body = request.SendMailRequest.emailsechome(),
            BodyEncoding = System.Text.Encoding.UTF8,
            SubjectEncoding = System.Text.Encoding.UTF8
        };

        _smtpSettings.ToUsers.ForEach(to => message.To.Add(to));

        try
        {
            client.SendAsync(message, cancellationToken);
        }
        catch
        {
            throw new SendNotificationOperationException("Email could not be sent!");
        }

        return Task.FromResult(GenericResult<NotificationSendMailResponse>.Success(new NotificationSendMailResponse { ResponseText = "Email Sent Successfull" }));
    }
}