using Smc.Domain.Models;

namespace Smc.Domain.Commands.Validations
{
    public class UpdateUserValidation : UserValidation<User>
    {
        public UpdateUserValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}