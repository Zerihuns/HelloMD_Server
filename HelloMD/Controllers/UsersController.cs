﻿using HelloMD.Dtos;
using HelloMD.Helpers;
using HelloMD.Services;
using HelloMD.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HelloMD.Controllers
{
    [Route("/api/users")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateRequestDto model)
        {
            var data = _userService.Authenticate(model);

            if (data.Item1 == null)
            {
                return BadRequest(new ResponseDto(false, "Username or password is incorrect","", null));

            }
            return Ok(new ResponseDto(true, "successfuly login", "user",data.Item1).AddData("token",data.Item2));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            Console.WriteLine(users.Count);
            return Ok(users);
        }
    }
}
