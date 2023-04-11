using Smc.Domain.Models;

namespace Smc.Domain.Commands.Validations
{
    public class RemoveUserValidation : UserValidation<User>
    {
        public RemoveUserValidation()
        {
            ValidateId();
        }
    }
}