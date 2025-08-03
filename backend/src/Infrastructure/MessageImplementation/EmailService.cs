using Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Models.Email;
using FluentEmail.Core;
using Microsoft.Extensions.Options;

namespace Ecommerce.Infrastructure.MessageImplementation;

public class EmailService : IEmailService
{
    private readonly IFluentEmail _fluentEmail;
    private readonly EmailFluentSettings _emailSettings;

public EmailService(IFluentEmail fluentEmail, IOptions<EmailFluentSettings> emailSettings)
    {
        _fluentEmail = fluentEmail;
        _emailSettings = emailSettings.Value;
    }

    public async Task<bool> SendEmailAsync(EmailMessage emailMessage, string token)
    {
        var htmlContent = $"<p>{emailMessage.Body}</p><p>Click <a href='{_emailSettings.BaseUrlClient}/password/reset/{token}'>here</a> to reset your email.</p>";

        var result = await _fluentEmail
            .To(emailMessage.To)
            .Subject(emailMessage.Subject ?? "No Subject")
            .Body(htmlContent, isHtml: true)
            .SendAsync();

        return result.Successful;
    }
}