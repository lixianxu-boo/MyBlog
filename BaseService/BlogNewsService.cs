using BaseService;
using MyBlog.IBaseService;
using MyBlog.IRepository;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BaseService
{
    public class BlogNewsService:BaseService<BlogNews>,IBlogNewsService
    {
        private readonly IBlogNewsRepository _iBlogNewsRepository;
        public BlogNewsService(IBlogNewsRepository iBlogNewsRepository)
        {
            base._iBaseRepository = iBlogNewsRepository;
            _iBlogNewsRepository = iBlogNewsRepository;
        }
    }
}
