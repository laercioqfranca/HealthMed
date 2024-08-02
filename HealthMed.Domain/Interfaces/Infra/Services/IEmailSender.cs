namespace HealthMed.Domain.Interfaces.Infra.Services
{

    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

}