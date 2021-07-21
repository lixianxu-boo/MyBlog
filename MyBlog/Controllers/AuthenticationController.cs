using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.WebApi.Controllers.Uni;
using MyBlog.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public ApiResult Login(string account,string pwd)
        {
            string token = string.Empty;
            var result = _authenticationService.IsAuthenticated(account, pwd, out token);
            if (result.Item1)
            {
                return ApiResultHelper.Success(token);
            }
            return ApiResultHelper.Error(result.Item2);
        }
    }
}
