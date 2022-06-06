using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Model.Entitys
{
    public class SysMenu
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string? Icon { get; set; }
        /// <summary>
        /// 菜单打开地址
        /// </summary>
        public string? Href { get; set; }
        /// <summary>
        /// 目标窗口
        /// </summary>
        public string? Target { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public string? ParentID { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperDate { get; set; } = DateTime.Now;
        /// <summary>
        /// 操作员
        /// </summary>
        public string? OperCode { get; set; }
        /// <summary>
        /// 菜单类型
        /// </summary>
        public int Type { get; set; }
    }
}
