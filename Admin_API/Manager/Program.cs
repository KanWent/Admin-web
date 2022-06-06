using Manager.Service.InterFace;
using Manager.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myCors", builde =>
    {
        builde.WithOrigins("*", "*", "*")
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ManagerAPI", Version = "v1" });
    //添加文档注释
    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
    var xmlPath = Path.Combine(basePath, "Manager.API.xml");
    c.IncludeXmlComments(xmlPath);
}
);





#region 依赖注入
//依赖注入
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IMenuService, MenuService>();
builder.Services.AddTransient<ICommonService, CommonService>();
#endregion
//日志配置
builder.Logging.AddLog4Net("Config/log4net.Config");

var app = builder.Build();




// Configure the HTTP request pipeline.
/// <summary>
/// 开发环境配置
/// </summary>
if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();
app.UseCors("myCors");

app.Run();
