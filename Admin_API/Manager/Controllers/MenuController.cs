using Manager.API.Helper;
using Manager.Model.Entitys;
using Manager.Service.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Manager.API.Controllers
{

    [Route("[controller]/[Action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMenuService _menuService;
        public MenuController(ILogger<UserController> logger, IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }
        /// <summary>
        /// 获取所有菜单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            var list = _menuService.GetAllMenu();
            if (list is null)
            {
                return Return.GetReturn(-1, "", new object());
            }
            return Return.GetReturn(1, "", list, list.Count);
        }
        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string Insert(string InJson)
        {

            string outjson = string.Empty;
            if (string.IsNullOrEmpty(InJson))
            {
                goto Error;
            }
            _logger.LogInformation(InJson);
            try
            {
                Menu menu = JsonConvert.DeserializeObject<Menu>(InJson);
                if (menu is null)
                {
                    goto Error;
                }
                int rc = _menuService.InsertMenu(menu);
                if (rc > 0) goto Error;
                goto Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                goto Error;
            }
        Error:
            outjson = Return.GetReturn(-1, "新增失败!", new object());
            goto Return;
        Success:
            outjson = Return.GetReturn(1, "新增成功!", new object());
            goto Return;
        Return:
            _logger.LogInformation(outjson);
            return outjson;

        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="InJson"></param>
        /// <returns></returns>
        [HttpPost]
        public string Update(string InJson)
        {
            string outjson = string.Empty;
            if (string.IsNullOrEmpty(InJson))
            {
                goto Error;
            }
            _logger.LogInformation(InJson);
            try
            {

                Menu menu = JsonConvert.DeserializeObject<Menu>(InJson);
                if (menu is null)
                {
                    goto Error;
                }
                int rc = _menuService.InsertMenu(menu);
                if (rc > 0) goto Error;
                goto Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                goto Error;
            }
        Error:
            outjson = Return.GetReturn(-1, "新增失败!", new object());
            goto Return;
        Success:
            outjson = Return.GetReturn(1, "新增成功!", new object());
            goto Return;
        Return:
            _logger.LogInformation(outjson);
            return outjson;
        }


    }
}
