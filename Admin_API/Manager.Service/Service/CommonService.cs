using Manager.DAL.DB;
using Manager.Model.Entitys;
using Manager.Service.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service.Service
{
    public class CommonService : ICommonService
    {
        public int Clear()
        {
            throw new NotImplementedException();
        }

        public Init InitMenu(ref string ErrMsg)
        {
            Init init = new();
            var homeInfo = DBContext.QuerySingle("select top 1 * from sys_menu where Type ='0'");
            if (homeInfo is null)
            {
                ErrMsg = "主页信息未能初始化！";
                goto Error;
            }
            var logoInfo = DBContext.QuerySingle("select top 1 * from sys_menu where Type ='1'");
            if (logoInfo is null)
            {
                ErrMsg = "主页图标未能初始化！";
                goto Error;
            }
            var MenusList = DBContext.Query("select   * from sys_menu where Type ='2'");
            if (MenusList is null)
            {
                ErrMsg = "菜单未能初始化！";
                goto Error;
            }
            init.homeInfo = new();
            init.logoInfo = new();
            init.menuInfo = new();

            init.homeInfo.title = homeInfo.Title;
            init.homeInfo.href = homeInfo.Href;

            init.logoInfo.title = logoInfo.Title;
            init.logoInfo.href = logoInfo.Href;
            init.logoInfo.image = logoInfo.Icon;

            var ParentMenu = MenusList.Where(m => m.ParentID is null || m.ParentID == -1).ToList();
            foreach (var item in ParentMenu)
            {
                MenuInfo menu = GetMenuInfo(item);
                GetChild(MenusList, menu);
                init.menuInfo.Add(menu);
            }
            goto Success;
        Error:
            return null;
        Success:
            return init;
        }

        /// <summary>
        /// 组装菜单信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private MenuInfo GetMenuInfo(dynamic item)
        {
            MenuInfo menu = new MenuInfo();
            menu.title = item.Title;
            menu.href = item.Href;
            menu.icon = item.Icon;
            menu.target = item.Target;
            menu.ID = item.ID;
            return menu;
        }
        /// <summary>
        /// 组装子节点
        /// </summary>
        /// <param name="menuList"></param>
        /// <param name="menu"></param>
        private void GetChild(List<dynamic> menuList, MenuInfo menu)
        {
            menu.child = new List<MenuInfo>();
            foreach (var item in menuList.Where(m => m.ParentID is not null && m.ParentID != -1 && m.ParentID == menu.ID))
            {
                MenuInfo chileMenu = GetMenuInfo(item);
                GetChild(menuList, chileMenu);
                menu.child.Add(chileMenu);
            }

        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        public int InsertMenu(SysMenu menu, ref string ErrMsg)
        {
            menu.CreateTime = DateTime.Now;
            ErrMsg = string.Empty;
            string maxIdSql = " select max(ID) from sys_Menu";

            string maxidval = DBContext.ExecuteScalar<string>(maxIdSql);
            int maxId = 0;
            if (!int.TryParse(maxidval, out maxId))
            {
                maxId = 0;
            }
            maxId++;
            string sql = $@"INSERT INTO [dbo].[sys_Menu]
           ([Title]
           ,[Icon]
           ,[Href]
           ,[Target]
           ,[ParentID]
           ,[ID]
           ,[Status]
           ,[CreateTime]
           ,[OperDate]
           ,[OperCode]
           ,[Type])
     VALUES
           ('{menu.Title}'
           ,'{menu.Icon}'
           ,'{menu.Href}'
           ,'{menu.Target}'
           ,'{menu.ParentID}'
           ,'{maxId}'
           ,'{menu.Status}'
           ,'{menu.CreateTime}'
           ,'{menu.OperDate}'
           ,'{menu.OperCode}'
           ,'{menu.Type}')";

            try
            {
                int rc = DBContext.Excute(sql);
                if (rc <= 0) ErrMsg = DBContext.ErrMsg;
                return rc;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }

        }
        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        public List<SysMenu> QueryAllMenu()
        {

            return DBContext.Query<SysMenu>("select * from sys_Menu");
        }

        public int UpdateMenu(SysMenu menu, ref string ErrMsg)
        {
            throw new NotImplementedException();
        }

        public int DeleteMenu(List<SysMenu> menulist, ref string ErrMsg)
        {
            throw new NotImplementedException();
        }
    }
}
