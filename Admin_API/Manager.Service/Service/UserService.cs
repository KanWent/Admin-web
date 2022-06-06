using Manager.DAL.DB;
using Manager.Service.Entiy;
using Manager.Service.InterFace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service.Service
{
    public class UserService : IUserService
    {
        public Login CheckLogin(Model.Entitys.User user, ref string ErrMsg)
        {

            var retUsers = DBContext.Query($"select * from sys_User where UserName='{user.UserName}' and Password = '{user.PassWord}'  order by  Status desc ");
            if (retUsers.Count == 0)
            {
                ErrMsg = string.IsNullOrEmpty(DBContext.ErrMsg) ? "用户名或者密码错误！" : DBContext.ErrMsg;
                return null;
            }
            if (retUsers[0].Status == 0)
            {
                ErrMsg = "用户状态失效！";
                return null;
            }
            Login outlogin = new Login();

            outlogin.UserName = retUsers[0].UserName;
            outlogin.UserID = retUsers[0].UserID;
            outlogin.token = Guid.NewGuid().ToString().Replace("-","");
            return outlogin;
        }
    }
}
