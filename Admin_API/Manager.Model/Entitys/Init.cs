using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Model.Entitys
{
    public class Init
    {
        /// <summary>
        /// 主页信息
        /// </summary>
        public HomeInfo homeInfo { get; set; }
        /// <summary>
        /// 图标信息
        /// </summary>
        public LogoInfo logoInfo { get; set; }

        /// <summary>
        /// 菜单信息
        /// </summary>
        public List<MenuInfo> menuInfo { get; set; }
    }


    public class HomeInfo
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string href { get; set; }
    }


    public class LogoInfo
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string href { get; set; }
    }


    public class MenuInfo
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string href { get; set; }
        /// <summary>
        /// ID
        /// </summary>


        public int ID { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public string target { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>

        public List<MenuInfo> child { get; set; }
    }
}
