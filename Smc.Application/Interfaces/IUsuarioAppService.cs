using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using NetDevPack.Identity.Model;
using Smc.Application.ViewModels;

namespace Smc.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetById(int id);
        UserViewModel Login(LoginUser loginUser);
        ValidationResult Register(UserViewModel UserViewModel);
        //ValidationResult Update(UserViewModel UserViewModel);
        //ValidationResult Remove(int id);
    }
}
