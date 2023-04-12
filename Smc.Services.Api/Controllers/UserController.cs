using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Smc.Application.Interfaces;
using Smc.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Smc.Services.Api.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserAppService _UserAppService;

        public UserController(IUserAppService UserAppService)
        {
            _UserAppService = UserAppService;
        }

        [AllowAnonymous]
        [HttpGet("Users")]
        public IEnumerable<UserViewModel> Get()
        {
            return _UserAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("Users/{id:guid}")]
        public UserViewModel Get(Guid id)
        {
            return  _UserAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpPost("Users")]
        public IActionResult Post(UserViewModel UserViewModel)
        {
            return CustomResponse(_UserAppService.Register(UserViewModel));
        }

        [AllowAnonymous]
        [HttpPut("Users")]
        public IActionResult Put([FromBody] UserViewModel UserViewModel)
        {
           return CustomResponse(_UserAppService.Update(UserViewModel));
        }

        [HttpDelete("Users")]
        public IActionResult Delete(Guid id)
        {
            return CustomResponse(_UserAppService.Remove(id));

        }

    }
}
