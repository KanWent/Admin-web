//
var ApiIP = "http://localhost:13714";
//菜单接口请求
window.MenuUrl = ApiIP + '/Menu/Get';
//初始化框架请求
window.InitUrl = ApiIP + '/Common/InitMenu';
//查询所有菜单
window.QueryAllMenuUrl = ApiIP + '/Common/QueryALLMenu';
//新增菜单
window.InsertMenu = ApiIP + '/Common/AddMenu';

//登录地址
window.LoginUrl = ApiIP+"User/Login";



window.PostURL = function (url, InJson, successfunc, errorfunc) {
    $.ajax({
        type: "post",
        url: url+"?InJson="+InJson,
        //data: { "InJson": InJson },
        success: successfunc,
        error: successfunc
    });
};



window.QueryAllMenu = function (successfunc) {
    $.ajax({
        type: "get",
        async: false,
        url: QueryAllMenuUrl,
        success: successfunc
    });
};


