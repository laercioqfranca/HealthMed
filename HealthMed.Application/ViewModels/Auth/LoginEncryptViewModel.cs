using System.ComponentModel.DataAnnotations;

namespace HealthMed.Application.ViewModels.Auth
{
    public class LoginEncryptViewModel
    {
        [Required(ErrorMessage = "A senha não foi informada!")]
        public string encrypted { get; set; }
    }
}
