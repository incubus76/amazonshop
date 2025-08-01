namespace Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Models.Email;

public interface IEmailService
{
    Task<bool> SendEmailAsync(EmailMessage emailMessage,string token);
}