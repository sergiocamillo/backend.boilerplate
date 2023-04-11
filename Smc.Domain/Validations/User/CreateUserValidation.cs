using Smc.Domain.Models;

namespace Smc.Domain.Commands.Validations
{
    public class CreateUserValidation : UserValidation<User>
    {
        public CreateUserValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}