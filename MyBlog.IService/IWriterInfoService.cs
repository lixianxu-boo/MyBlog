using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.IBaseService
{
    public interface IWriterInfoService:IBaseService<WriterInfo>
    {
        Tuple<bool, string, WriterInfo> CheckLogin(string account, string pwd);
    }
}
