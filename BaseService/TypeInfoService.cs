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
    public class TypeInfoService:BaseService<TypeInfo>,ITypeInfoService
    {
        private readonly ITypeInfoRepository _iTypeInfoRepository;

        public TypeInfoService(ITypeInfoRepository iTypeInfoRepository)
        {
            base._iBaseRepository = iTypeInfoRepository;
            _iTypeInfoRepository = iTypeInfoRepository;
        }
    }
}
