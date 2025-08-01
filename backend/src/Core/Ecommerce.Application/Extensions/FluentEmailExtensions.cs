using Ecommerce.Application.Models.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application.Extensions;

public static class FluentEmailExtensions
{
    public static void AddServiceEmail(this IServiceCollection services, IConfiguration configuration)
    {
        // Register EmailFluentSetting from configuration
        services.Configure<EmailFluentSetting>(configuration.GetSection(nameof(EmailFluentSetting)));

        var emailSetting = configuration.GetSection(nameof(EmailFluentSetting));
        var fromEmail = emailSetting.GetValue<string>("Email");
        var host = emailSetting.GetValue<string>("Host");
        var port = emailSetting.GetValue<int>("Port");
        var baseUrlClient = emailSetting.GetValue<string>("BaseUrlClient");

        services.AddFluentEmail(fromEmail)
            .AddSmtpSender(host,port);
    }
}