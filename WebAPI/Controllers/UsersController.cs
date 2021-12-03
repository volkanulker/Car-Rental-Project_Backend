using Business.Abstract;
using Core.Entities;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            // Try to Login
            var userToLogin = _authService.Login(userForLoginDto);
            // if login is not succesfull
            if (!userToLogin.Success)
            {
                // return error message
                return BadRequest(userToLogin.Message); 
            }
            // if login is successfull create a access token
            var result = _authService.CreateAccessToken(userToLogin.Data);
            // is accesss token created succesfully
            if (result.Success)
            {
                // return access token
                return Ok(result.Data);
            }
            // if access token can not created return error message
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            // check whether user exists
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            // if user does not exist
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            // if user exist
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }


    }
}
