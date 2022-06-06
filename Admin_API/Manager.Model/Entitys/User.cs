using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Model.Entitys
{
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; } = 0;
        /// <summary>
        /// 用户名
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string? PassWord { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int? RoleID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? Status { get; set; }

    }
}
