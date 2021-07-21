using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IBaseService;
using MyBlog.Model;
using MyBlog.WebApi.Controllers.Uni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeInfoController : ControllerBase
    {
        private readonly ITypeInfoService _iTypeInfoService;

        public TypeInfoController(ITypeInfoService iTypeInfoService)
        {
            _iTypeInfoService = iTypeInfoService;
        }
        [HttpGet("Type")]
        public async Task<ApiResult> Get()
        {
            var result = await _iTypeInfoService.QueryAsync();
            return ApiResultHelper.Success(result);
        }
        [HttpPost("Create")]
        public async Task<ApiResult> Create(string name)
        {
            var type = new TypeInfo() { Name = name };
            var result = await _iTypeInfoService.CreatAsync(type);
            if (result) return ApiResultHelper.Success(result);
            return ApiResultHelper.Error("添加失败");
        }
        [HttpPut("Edit")]
        public async Task<ApiResult> Edit(int id, string name)
        {
            var type = await _iTypeInfoService.FindAsync(id);
            if (type == null) return ApiResultHelper.Error("没有找到文章类型");
            type.Name = name;
            var result = await _iTypeInfoService.EditAsync(type);
            if (result) return ApiResultHelper.Success(result);
            return ApiResultHelper.Error();
        }
        [HttpDelete("Delete")]
        public async Task<ApiResult> Delete(int id)
        {
            var type = await _iTypeInfoService.FindAsync(id);
            var result = await _iTypeInfoService.DeleteAsync(type);
            if (result) return ApiResultHelper.Success(result);
            return ApiResultHelper.Error();
        }
    }
}
