using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IBaseService;
using MyBlog.Model;
using MyBlog.WebApi.Controllers.Uni;
using MyBlog.WebApi.Uni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterInfoController : ControllerBase
    {
        private readonly IWriterInfoService _iWriterInfoService;

        public WriterInfoController(IWriterInfoService iWriterInfoService)
        {
            _iWriterInfoService = iWriterInfoService;
        }
        [HttpPost("Create")]
        public async Task<ApiResult> Create(string name, string username, string userpwd)
        {
            //数据验证
            var writerinfo = new WriterInfo()
            {
                UserName = username,
                UserPwd = Md5Helper.Md5Encrypt32(userpwd),
                Name = name
            };
            var oldWriterModel = await _iWriterInfoService.FindAsync(a => a.UserName == username);
            if (oldWriterModel == null)
            {
                var result = await _iWriterInfoService.CreatAsync(writerinfo);
                if (result) return ApiResultHelper.Success(writerinfo);
                return ApiResultHelper.Error();
            }
            return ApiResultHelper.Error("已经存在该账号");
        }
        [HttpPost("Edit")]
        public async Task<ApiResult> Edit(string name)
        {
            int id = Convert.ToInt32(this.User.FindFirst("Id").Value);
            return ApiResultHelper.Error("");
        }

    }
}
