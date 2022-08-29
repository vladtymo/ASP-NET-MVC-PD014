using FirstAspNetMvc_project.Utilities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;

namespace FirstAspNetMvc_project.Services
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string html, string from = null);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendAsync(string to, string subject, string html, string from = null)
        {
            MailData data = configuration.GetSection(nameof(MailData)).Get<MailData>();

            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? data.Username));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(data.SmtpHost, data.SmtpPort, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(data.Username, data.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
