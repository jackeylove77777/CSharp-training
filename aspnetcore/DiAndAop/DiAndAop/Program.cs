using DiAndAop.Services;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using DiAndAop.AutofacSetup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//�����������ڣ�������������˲̬
//�����������ۺ�ʱ�õ��ķ���ʵ������ͬһ������
//Asp.net core�У�ÿ��������������һ��������ͬһ������������ķ����������ͬ��
//˲̬ÿ�λ�ȡ�ķ������ʵ������һ��
builder.Services.AddSingleton<SingletonServ>();
builder.Services.AddScoped<ScopeServ>();
builder.Services.AddTransient<TransientServ>();

//ʹ��Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(cbuilder =>  cbuilder.RegisterModule<AutofacRegisterModule>());

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
