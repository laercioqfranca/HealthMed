using FluentValidation;
using HealthMed.Core.Commands;

namespace HealthMed.Domain.Validations
{
    public class CommandValidation<T> : AbstractValidator<T> where T : Command
    {
    }
}
