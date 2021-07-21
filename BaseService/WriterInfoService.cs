using BaseService;
using MyBlog.Code;
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
    public class WriterInfoService : BaseService<WriterInfo>, IWriterInfoService
    {
        private readonly IWriterInfoRepository _iWriterInfoRepository;

        public WriterInfoService(IWriterInfoRepository iWriterInfoRepository)
        {
            base._iBaseRepository = iWriterInfoRepository;
            _iWriterInfoRepository = iWriterInfoRepository;
        }

        public  Tuple<bool, string, WriterInfo> CheckLogin(string account, string pwd)
        {
            var password = Md5Helper.Md5Encrypt32(pwd);
            var writerModel= _iWriterInfoRepository.Find(a => a.UserName == account && a.UserPwd == password);
            if (writerModel != null) return Tuple.Create(true, string.Empty, writerModel);
            return Tuple.Create(false, "账户或密码错误", writerModel);
        }

    }
}
