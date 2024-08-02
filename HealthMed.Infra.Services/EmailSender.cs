using Microsoft.Extensions.Options;
using HealthMed.Domain.Interfaces.Infra.Services;
using HealthMed.Domain.Services;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;

namespace HealthMed.Infra.Services
{

    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        EmailConfig _email;

        public EmailSender(IOptions<EmailConfig> email,
            IConfiguration configuration)
        {
            _config = configuration;
            _email = email.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {

                await Execute(email, subject, message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao enviar e-mail! " + ex.Message);
            }
        }

        private async Task Execute(string email, string subject, string messageBody)
        {
            try
            {
                string? smtp = _config.GetSection("Smtp").Value;
                string? smtpUserName = _config.GetSection("SmtpUserName").Value;
                string? smtpPassword = _config.GetSection("SmtpPassword").Value;

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Health Med", "agendamento@healthmed.com"));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = subject;
                message.Body = new TextPart("html") { Text = messageBody };

                using (var client = new SmtpClient())
                {
                    client.Connect(smtp, 587, SecureSocketOptions.StartTls);
                    client.Authenticate(smtpUserName, smtpPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}