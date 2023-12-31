﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ILoginService _dataRepository;
        private static Logger logger = LogManager.GetLogger("LoginController");
        public LoginController(IMapper mapper, ILoginService dataRepository)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }

        //[Microsoft.AspNetCore.Mvc.HttpPost("Login")]
        //[Authorize]
        //public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        //{
        //    var response = await _dataRepository.LoginDetails(loginRequestDto);
        //    if (response == null)
        //    {
        //        return BadRequest("User ID or Password is Wrong");
        //    }
        //    else
        //    {
        //        return Ok(response);
        //    }
        //}
    }
}
