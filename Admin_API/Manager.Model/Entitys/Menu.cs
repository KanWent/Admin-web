using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Model.Entitys
{
    public class Menu
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int authorityId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string authorityName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int orderNumber { get; set; }
        /// <summary>
        /// 菜单地址
        /// </summary>
        public string menuUrl { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string menuIcon { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string authority { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        [JsonProperty("checked")]
        public int Checked { get; set; } = 0;
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime updateTime { get; set; }
        /// <summary>
        /// 是否是连接菜单
        /// </summary>
        public int isMenu { get; set; } = 0;
        /// <summary>
        /// 状态
        /// </summary>

        public int status { get; set; }
        /// <summary>
        /// 父级菜单ID
        /// </summary>
        public int parentId { get; set; } = -1;
    }
}
