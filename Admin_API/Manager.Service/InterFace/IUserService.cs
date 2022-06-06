using Manager.Service.Entiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service.InterFace
{
    public interface IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Login CheckLogin(Model.Entitys.User user, ref string ErrMsg);

    }
}
