using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroTier.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/users/register")]
        public HttpResponseMessage Create(UserDTO u)
        {
            UserService.Create(u);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost]
        [Route("api/users/login")]
        public HttpResponseMessage Login(UserDTO loginDto)
        {
            try
            {
                var result = UserService.Login(loginDto.Email, loginDto.Password);

                if (result == "Logged in successfully")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, result);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


    }
}
