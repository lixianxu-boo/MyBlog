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
    public class WriterInfoService:BaseService<WriterInfo>,IWriterInfoService
    {
        private readonly IWriterInfoRepository _iWriterInfoRepository;

        public WriterInfoService(IWriterInfoRepository iWriterInfoRepository)
        {
            base._iBaseRepository = iWriterInfoRepository;
            _iWriterInfoRepository = iWriterInfoRepository;
        }
    }
}
