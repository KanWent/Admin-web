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
    public class MenuService : IMenuService
    {
        public int DeltetMenu(Menu menu)
        {
            string sql = $@" deltet from  Menu  where authorityId='{menu.authorityId}'";
            return DBContext.Excute(sql);
        }

        public List<Menu> GetAllMenu()
        {
            var list = DBContext.Query($"select * from Menu");
            if (list is null)
            {
                return default;

            }
            List<Menu> menuList = new List<Menu>();
            foreach (var item in list)
            {
                Menu menu = new Menu();
                menu.authorityName = item.authorityName;
                menu.authority = item.authority;
                menu.authorityId = item.authorityId;
                menu.menuUrl = item.menuUrl;
                menu.createTime = item.createTime;
                menu.updateTime = item.updateTime;
                menu.menuIcon = item.menuIcon;
                menu.isMenu = item.isMenu;
                menu.parentId = item.ParentID is null ? -1 : item.ParentID;
                menu.Checked = item.Checked;
                menu.status = item.status;
                menu.orderNumber = item.orderNumber;
                menuList.Add(menu);
            }
            return menuList;
        }

        public Menu GetMenuById(int id)
        {
            var list = DBContext.Query($"select * from Menu where authorityId ='{id}'");
            Menu menu = new Menu();
            do
            {
                var item = list[0];
                menu.authorityName = item.authorityName;
                menu.authority = item.authority;
                menu.authorityId = item.authorityId;
                menu.menuUrl = item.menuUrl;
                menu.createTime = item.createTime;
                menu.updateTime = item.updateTime;
                menu.menuIcon = item.menuIcon;
                menu.isMenu = item.isMenu;
                menu.parentId = item.ParentID is null ? -1 : item.ParentID;
                menu.Checked = item.Checked;
                menu.status = item.status;
                menu.orderNumber = item.orderNumber;
            } while (false);
            return menu;
        }

        public int InsertMenu(Menu menu)
        {
            string sql = $@"INSERT INTO [dbo].[Menu]
           ([authorityId]
           ,[authorityName]
           ,[orderNumber]
           ,[menuUrl]
           ,[menuIcon]
           ,[createTime]
           ,[authority]
           ,[Checked]
           ,[updateTime]
           ,[isMenu]
           ,[parentId]
           ,[status])
     VALUES
           ( '{menu.authorityId}'
           ,'{menu.authorityName}'
           ,'{menu.orderNumber}'
           ,'{menu.menuUrl}'
           ,'{menu.menuIcon}'
           ,'{menu.createTime}'
           ,'{menu.authority}'
           ,'{menu.Checked}'
           ,'{menu.updateTime}'
           ,'{menu.isMenu}'
           ,'{menu.parentId}'
           , '{menu.status}')";

            return DBContext.Excute(sql);
        }

        public int UpdateMenu(Menu menu)
        {
            string sql = $@" UPDATE [dbo].[Menu]
   SET [authorityId] = '{menu.authorityId}'
      ,[authorityName] = '{menu.authorityName}'
      ,[orderNumber] =  '{menu.orderNumber}'
      ,[menuUrl] =  '{menu.menuUrl}'
      ,[menuIcon] = '{menu.menuIcon}'
      ,[createTime] = '{menu.createTime}'
      ,[authority] =  '{menu.authority}'
      ,[Checked] =  '{menu.Checked}'
      ,[updateTime] = '{menu.updateTime}'
      ,[isMenu] =  '{menu.isMenu}'
      ,[parentId] = '{menu.parentId}'
      ,[status] =  '{menu.status}'
 WHERE [authorityId] = '{menu.authorityId}'";
            return DBContext.Excute(sql);
        }
    }
}
