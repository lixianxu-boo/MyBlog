using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Controllers.Uni
{
    public static class ApiResultHelper
    {
       public static ApiResult Success(dynamic data)
        {
            return new ApiResult
            {
                Code = 200,
                Msg = "操作成功",
                Data = data,
                Total = 0
            };
        }

        public static ApiResult Success(dynamic data,RefAsync<int> total)
        {
            return new ApiResult
            {
                Code = 200,
                Msg = "操作成功",
                Data = data,
                Total = total
            };
        }

        public static ApiResult Error(string msg="操作失败")
        {
            return new ApiResult
            {
                Code = 500,
                Data = null,
                Msg = msg,
                Total = 0
            };
        }

    }
}
