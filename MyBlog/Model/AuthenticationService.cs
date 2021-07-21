using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyBlog.IBaseService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Model
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly TokenManagement _tokenManagement;
        private IWriterInfoService _userService;

        public AuthenticationService(IOptions<TokenManagement> tokenManagement,IWriterInfoService userService)
        {
            _tokenManagement = tokenManagement.Value;
            _userService = userService;
        }
        public Tuple<bool, string> IsAuthenticated(string account, string pwd, out string token)
        {
            try
            {
                token = string.Empty;
                var loginResult = _userService.CheckLogin(account, pwd);
                if (!loginResult.Item1)
                {
                    return Tuple.Create(false, loginResult.Item2);
                }
                var user = loginResult.Item3;
                var claims = new[]
                {
                    new Claim("UserToken",user?.Id.ToString()),
                    new Claim("UserAccount",user?.UserName.ToString())};

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims, expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration), signingCredentials: credentials);
                token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                return Tuple.Create(true, token);
            }
            catch (Exception ex)
            {
                token = string.Empty;
                return Tuple.Create(false, "登录失败:" + ex.Message);
            }
        }
    }
}
