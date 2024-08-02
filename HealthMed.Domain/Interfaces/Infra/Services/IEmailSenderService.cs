namespace HealthMed.Domain.Interfaces.Infra.Services
{

    public interface IEmailSenderService
    {
        Task EnviarEmail(string titulo, string mensagem, string email);
    }

}