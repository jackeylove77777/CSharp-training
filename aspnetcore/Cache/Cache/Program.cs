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
//���Redis����
//appsettings.json��дredis������Ϣ������д����������Ϣ��Redis��Ⱥ��
builder.Services.AddDistributedRedisCache(option =>
{
    option.InstanceName = "cacheTest_";//��ǰ׺
    option.Configuration=builder.Configuration.GetConnectionString("Redis");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//ʹ�÷����������м��
//�����ʱ����[ResponseCache]���õ�һ����ͬһ���������᲻�����������棬��Ϊ����������ҵ����صĻ�����Ӧ���ٿ�����һ�����������20����
//�õ�����Ӧ���һ�������һ��
//���ǿͻ��˼���cache-control��no-cache��ʱ�򣬷���������ʧЧ����ʹ�ö��⹥��������Լ����������ͷ�����⹥�������������ƻ��洩͸
//app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
