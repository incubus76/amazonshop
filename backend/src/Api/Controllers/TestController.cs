using Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Models.Email;
using Microsoft.AspNetCore.Mvc;

namespace   Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IEmailService _emailService;

    public TestController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task<IActionResult> SendTestEmail()
    {
        var emailMessage = new EmailMessage
        {
            To = "impipo@gmail.com",
            Subject = "Test Email",
            Body = "This is a test email from the Ecommerce application."
        };
        await _emailService.SendEmailAsync(emailMessage, "test-token");
        return Ok("Email sent successfully.");
    }

}