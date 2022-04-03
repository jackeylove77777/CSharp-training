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
//三种生命周期，单例，作用域，瞬态
//单例，即无论何时得到的服务实例都是同一个对象
//Asp.net core中，每个独立的请求都是一个作用域，同一个作用域申请的服务对象是相同的
//瞬态每次获取的服务对象实例都不一样
builder.Services.AddSingleton<SingletonServ>();
builder.Services.AddScoped<ScopeServ>();
builder.Services.AddTransient<TransientServ>();

//使用Autofac
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
