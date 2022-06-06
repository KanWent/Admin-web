using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Manager.Service.InterFace;
using Newtonsoft.Json;
using Manager.API.Helper;

namespace Manager.API.Controllers
{

    [Route("[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
       
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// 获取指定用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            _logger.LogError("错误");
            _logger.LogInformation("调用GetUser");
            return "GetUser";
        }


        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public string Login(string UserName, string Pwd)
        {
            string ErrMsg = string.Empty;
            Manager.Model.Entitys.User user = new Manager.Model.Entitys.User() { UserName = UserName, PassWord = Pwd };
            Manager.Service.Entiy.Login login = _userService.CheckLogin(user, ref ErrMsg);

            
            if (login is null)
            {

                return Return.GetReturn<object>(-1,"登录失败",null);
            }

            return Return.GetReturn<Manager.Service.Entiy.Login>(1, "登录成功", login);
        }
    }
}
