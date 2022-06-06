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
    //����ĵ�ע��
    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
    var xmlPath = Path.Combine(basePath, "Manager.API.xml");
    c.IncludeXmlComments(xmlPath);
}
);





#region ����ע��
//����ע��
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IMenuService, MenuService>();
builder.Services.AddTransient<ICommonService, CommonService>();
#endregion
//��־����
builder.Logging.AddLog4Net("Config/log4net.Config");

var app = builder.Build();




// Configure the HTTP request pipeline.
/// <summary>
/// ������������
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
