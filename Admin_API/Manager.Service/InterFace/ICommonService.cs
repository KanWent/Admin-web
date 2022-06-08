using Manager.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service.InterFace
{
    public interface ICommonService
    {
        /// <summary>
        /// 初始化  
        /// </summary>
        /// <returns></returns>
        Init InitMenu(ref string ErrMsg);
        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        int InsertMenu(SysMenu menu, ref string ErrMsg);
        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        List<SysMenu> QueryAllMenu();

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        int UpdateMenu(SysMenu menu, ref string ErrMsg);
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menulist"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        int DeleteMenu(List<SysMenu> menulist, ref string ErrMsg);

        /// <summary>
        /// 清除服务端缓存
        /// </summary>
        /// <returns></returns>
        int Clear();
    }
}
