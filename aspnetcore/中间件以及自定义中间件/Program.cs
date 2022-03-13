using 中间件以及自定义中间件.CustomMiddleware;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//注册自定义中间件，中间件执行的顺寻按照注册的顺序来执行，例如现在是UseHttpsRedirection->UseAuthorization->UseCustomLog
app.UseCustomLog();
app.MapControllers();

app.Run();
