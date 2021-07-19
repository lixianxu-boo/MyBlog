using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Controllers.Uni
{
    public class ApiResult
    {
        public int Code { get; set; }
        public object Data { get; set; }

        public string Msg { get; set; }

        public int Total { get; set; }

    }
}
