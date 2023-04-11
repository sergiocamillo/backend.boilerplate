using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using AutoMapper;
using Smc.Application.Interfaces;
using Smc.Domain.Interfaces;
using Smc.Application.ViewModels;
using Smc.Domain.Commands;
using NetDevPack.Identity.Model;
using Smc.Application.Password;
using System.Linq;
using Smc.Domain.Models;
using Smc.Domain.Commands.Validations;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using Smc.Infra.CrossCutting.Commun.Exceptions;

namespace Smc.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserAppService(IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(_userRepository.GetAll());
        }

        public UserViewModel GetById(int id)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetById(id));
        }

        public UserViewModel Login(LoginUser loginUser)
        {
            loginUser.Password = PasswordEncription.Provider.EncriptPassword(loginUser.Password, ""); //TODO include pwd salt for the application

            User user = _userRepository.Login(loginUser.Email, loginUser.Password);

            if (user != null || user == default) {
                throw new RNException("User or password doesn't match!");
            }

            var result = _mapper.Map<UserViewModel>(user);

            return result;
        }

        public FluentValidation.Results.ValidationResult Register(UserViewModel userViewModel)
        {
            User user = _mapper.Map<User>(userViewModel);

            var userValidation = new CreateUserValidation();
            var validationResult = userValidation.Validate(user);

            if (validationResult.IsValid) {
                user.Password = PasswordEncription.Provider.EncriptPassword(user.Password, ""); //TODO include pwd salt for the application
                _userRepository.Add(user);
            }

            return validationResult;
        }

        //public async Task<ValidationResult> Update(UserViewModel customerViewModel)
        //{
        //    var updateCommand = _mapper.Map<UpdateUserCommand>(customerViewModel);
        //}

        //public async Task<ValidationResult> Remove(int id)
        //{
        //    var removeCommand = new RemoveUserCommand(id);
        //    return await _mediator.SendCommand(removeCommand);
        //}


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    
    }
}
