using Cache;

Statics.timer.Elapsed += Statics.OnTimedEvent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<MockContext>();
builder.Services.AddMemoryCache();
//添加Redis缓存
//appsettings.json填写redis配置信息，可以写多组配置信息（Redis集群）
builder.Services.AddDistributedRedisCache(option =>
{
    option.InstanceName = "cacheTest_";//键前缀
    option.Configuration=builder.Configuration.GetConnectionString("Redis");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//使用服务器缓存中间件
//缓存的时长和[ResponseCache]设置的一样，同一个浏览器体会不出服务器缓存，因为浏览器会先找到本地的缓存响应，再开另外一个浏览器，在20秒内
//得到的响应与第一个浏览器一样
//但是客户端加上cache-control：no-cache的时候，服务器缓存失效，这使得恶意攻击程序可以加上这个报文头来恶意攻击服务器，类似缓存穿透
//app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
