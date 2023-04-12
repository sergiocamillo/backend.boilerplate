using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using AutoMapper;
using Smc.Application.Interfaces;
using Smc.Domain.Interfaces;
using Smc.Application.ViewModels;
using Smc.Domain.Commands;
using Smc.Application.Password;
using System.Linq;
using Smc.Domain.Models;
using Smc.Domain.Commands.Validations;
using FluentValidation.Results;
using Smc.Infra.CrossCutting.Commun.Exceptions;
using Smc.Infra.Data;

namespace Smc.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserAppService(IMapper mapper,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;   
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(_userRepository.GetAll());
        }

        public UserViewModel GetById(Guid id)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetById(id));
        }

        public UserViewModel Login(LoginUserViewModel loginUser)
        {
            loginUser.Password = PasswordEncription.Provider.EncriptPassword(loginUser.Password, ""); //TODO need include pwd salt for the application

            User user = _userRepository.Login(loginUser.Email, loginUser.Password);

            if (user == null || user == default) {
                throw new RNException("User or password doesn't match!");
            }

            var result = _mapper.Map<UserViewModel>(user);

            return result;
        }

        public ValidationResult Register(UserViewModel userViewModel)
        {
            try
            {
                User user = _mapper.Map<User>(userViewModel);

                var userValidation = new CreateUserValidation();
                var validationResult = userValidation.Validate(user);

                if (validationResult.IsValid)
                {
                    user.Password = PasswordEncription.Provider.EncriptPassword(user.Password, ""); //TODO include pwd salt for the application
                
                    _userRepository.Add(user);
                }

                return validationResult;
            }
            catch (Exception ex)
            {
                throw;
            }
         
        }

        public ValidationResult Update(UserViewModel userViewModel)
        {
            User user = _mapper.Map<User>(userViewModel);

            var userValidation = new UpdateUserValidation();
            var validationResult = userValidation.Validate(user);

            if (validationResult.IsValid)
            {
                user.Password = PasswordEncription.Provider.EncriptPassword(user.Password, ""); //TODO include pwd salt for the application

                _userRepository.Update(user);
            }

            return validationResult;
        }

        public ValidationResult Remove(Guid id)
        {
            var userValidation = new RemoveUserValidation();
            User user = new User(id, string.Empty, string.Empty, DateTime.Now, Guid.Empty);

            var validationResult = userValidation.Validate(user);

            if (validationResult.IsValid)
            {
                _userRepository.Remove(id);
            }

            return validationResult;

        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    
    }
}
