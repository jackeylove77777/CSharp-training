using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
//若访问的路径是一个文件目录，那么会返回默认的一个文件，比如index.html
//要注意与 UseDirectoryBrowser() 的顺序，UseDefaultFiles在请求管道之前，那么就算访问了一个目录，也会默认返回静态文件,不建议与UseDirectoryBrowser一起使用
app.UseDefaultFiles();
//若访问的路径是一个文件目录，则返回一个页面，页面包含了该目录下所有文件的链接
app.UseDirectoryBrowser();
//静态文件支持，默认目录为wwwroot
app.UseStaticFiles();
//自定义目录
app.UseStaticFiles(new StaticFileOptions()
{
    RequestPath = "/files",   //若不设置，则默认为根目录
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "file"))
});

//自定义路由终点，将所有不是以api为前缀路由的请求全都返回静态文件根目录的默认文件index.html，但由于上面静态文件中间件注册早于这里
//所以，碰上存在的静态文件目录就会返回，请求并不会走到这里
app.MapWhen(context =>
{
    return !context.Request.Path.Value.StartsWith("/api");
}, appbuilder =>
{
    var rewriter = new RewriteOptions();
    rewriter.AddRewrite(".*", "/index.html", true);
    appbuilder.UseRewriter(rewriter);
    appbuilder.UseStaticFiles();
});


app.UseAuthorization();

app.MapControllers();

app.Run();
