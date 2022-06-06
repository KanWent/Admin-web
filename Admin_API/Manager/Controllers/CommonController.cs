using Manager.Service.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Manager.Model.Entitys;
using Manager.API.Helper;

namespace Manager.API.Controllers
{

    [Route("[controller]/[Action]")]
    [ApiController]

    public class CommonController : ControllerBase
    {

        private readonly ILogger<CommonController> _logger;

        private readonly ICommonService _commonService;
        private readonly IConfiguration Configuration;
        public CommonController(ILogger<CommonController> logger, ICommonService commonService, IConfiguration configuration)
        {
            _logger = logger;
            _commonService = commonService;
            Configuration = configuration;
            var myKeyValue = Configuration["ConnectionStrings:key"];
        }


        /// <summary>
        /// 初始化获取所有菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string InitMenu()
        {
            _logger.LogInformation("调用初始化");
            string errMsg = string.Empty;
            Manager.Model.Entitys.Init init = _commonService.InitMenu(ref errMsg);
            if (init is null)
            {
                _logger.LogInformation(errMsg);
                init = new Model.Entitys.Init();
            }
            string OutJson = JsonConvert.SerializeObject(init);
            _logger.LogInformation("出参：" + OutJson);
            return OutJson;
        }

        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string QueryALLMenu()
        {
            /*
              
             */
            var list = _commonService.QueryAllMenu();
            return Return.GetReturn(0, "", list,list.Count) ;
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddMenu")]
        public string InsertMenu(string InJson)
        {
            _logger.LogInformation("调用新增菜单 入参：" + InJson);
            string ErrMsg = string.Empty;
            string OutJson = string.Empty;
            try
            {
                SysMenu menu = JsonConvert.DeserializeObject<SysMenu>(InJson);
                if (menu is null)
                {
                    ErrMsg = "入参有误！";
                    goto Error;
                }
                int rc = _commonService.InsertMenu(menu, ref ErrMsg);
                if (rc <= 0)
                {
                    goto Error;
                }
            }
            catch (Exception)
            {
                ErrMsg = "入参有误！";
                goto Error;
            }
            goto Success;
        Error:
            _logger.LogError(ErrMsg);
            OutJson = Return.GetReturn(-1, ErrMsg, new object());
            goto Return;
        Success:
            OutJson = Return.GetReturn(1, "新增成功", new object());
            goto Return;
        Return:
            _logger.LogInformation("出参：" + OutJson);
            return OutJson;
        }


    }
}
