using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Model
{
    public interface IAuthenticationService
    {
        Tuple<bool, string> IsAuthenticated(string account, string pwd, out string token);
    }
}
