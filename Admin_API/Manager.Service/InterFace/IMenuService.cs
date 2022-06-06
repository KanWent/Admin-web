using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service.InterFace
{
    public interface IMenuService
    {
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        List<Model.Entitys.Menu> GetAllMenu();
        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        int InsertMenu(Model.Entitys.Menu menu);

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        int UpdateMenu(Model.Entitys.Menu menu);
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        int DeltetMenu(Model.Entitys.Menu menu);
        /// <summary>
        /// 根据菜单ID查询指定菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Model.Entitys.Menu  GetMenuById(int id);
    }
}
