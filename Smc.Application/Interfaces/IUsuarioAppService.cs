using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using Smc.Application.ViewModels;

namespace Smc.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetById(Guid id);
        UserViewModel Login(LoginUserViewModel loginUser);
        ValidationResult Register(UserViewModel UserViewModel);
        ValidationResult Update(UserViewModel UserViewModel);
        ValidationResult Remove(Guid id);
    }
}
