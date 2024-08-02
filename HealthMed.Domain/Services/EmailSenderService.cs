using HealthMed.Domain.Interfaces.Infra.Services;

namespace HealthMed.Domain.Services
{

    public class EmailSenderService : IEmailSenderService
    {

        private readonly IEmailSender _emailSender;

        public EmailSenderService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task EnviarEmail(string titulo, string mensagem, string email)
        {
            await _emailSender.SendEmailAsync(email, titulo, mensagem);
        }
    }

    public class EmailConfig
    {
        public EmailConfig()
        {

        }

        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string UsernameEmail { get; set; }
        public string UsernamePassword { get; set; }
        public string FromEmail { get; set; }
    }

}