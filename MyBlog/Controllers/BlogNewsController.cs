using Microsoft.AspNetCore.Authorization;
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
    public class BlogNewsController : ApiControllerBase
    {
        private readonly IBlogNewsService _iBlogNewsService;

        public BlogNewsController(IBlogNewsService iBlogNewsService)
        {
            _iBlogNewsService = iBlogNewsService;
        }
        [HttpGet("BlogNews")]
        public async Task<ApiResult> GetBolgNews()
        {
            var data = await _iBlogNewsService.QueryAsync();
            if (data == null) return ApiResultHelper.Error("找不到更多资源");
            return ApiResultHelper.Success(data);
        }
        [HttpPost("Creat")]
        public async Task<ApiResult> Creat(string title, string content, int typeid)
        {
            BlogNews blognews = new BlogNews
            {
                Title = title,
                Content = content,
                LikeCount = 0,
                Time = DateTime.Now,
                BrowseCount = 0,
                TypeId = typeid,
                WriterId = 1
            };
            var result = await _iBlogNewsService.CreatAsync(blognews);
            if (result) return ApiResultHelper.Success(result);
            return ApiResultHelper.Error("添加失败");
        }

        [HttpDelete("Delete")]
        public async Task<ApiResult> Delete(int id)
        {
            var model =await  _iBlogNewsService.FindAsync(id);
            var result = await _iBlogNewsService.DeleteAsync(model);
            if (result) return ApiResultHelper.Success(result);
            return ApiResultHelper.Error();
        }
        [HttpPost]
        public async Task<ApiResult> Edit(int id,string title,string content,int typeid)
        {
            var model = await _iBlogNewsService.FindAsync(id);
            model.Title = title;
            model.Content = content;
            model.TypeId = typeid;
            var result = await _iBlogNewsService.EditAsync(model);
            if (result) return ApiResultHelper.Success(result);
            return ApiResultHelper.Error();

        }
    }
}
