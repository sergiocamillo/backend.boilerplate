using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Smc.Application.Interfaces;
using Smc.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;

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
        [HttpGet("User-management")]
        public IEnumerable<UserViewModel> Get()
        {
            return _UserAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("User-management/{id:guid}")]
        public UserViewModel Get(int id)
        {
            return  _UserAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpPost("User-management")]
        public async Task<IActionResult> Post(UserViewModel UserViewModel)
        {
            return CustomResponse(_UserAppService.Register(UserViewModel));
        }

        //[AllowAnonymous]
        //[HttpPut("User-management")]
        //public async Task<IActionResult> Put([FromBody] UserViewModel UserViewModel)
        //{
        //    return CustomResponse( _UserAppService.Update(UserViewModel));
        //}

        //[CustomAuthorize("Users", "Remove")]
        //[HttpDelete("User-management")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return CustomResponse( _UserAppService.Remove(id));
        //}

    }
}
