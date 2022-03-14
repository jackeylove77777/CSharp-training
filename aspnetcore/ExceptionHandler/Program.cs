using ExceptionHandler.Exceptions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//添加异常过滤器
builder.Services.AddMvc(mvcOption =>
{
    mvcOption.Filters.Add<ExceptionFilter>();
    mvcOption.Filters.Add<MyExceptionFilterAttribute>();
}).AddJsonOptions(jsonoptions =>
{
    jsonoptions.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
