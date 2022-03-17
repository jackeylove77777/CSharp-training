using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
//�����ʵ�·����һ���ļ�Ŀ¼����ô�᷵��Ĭ�ϵ�һ���ļ�������index.html
//Ҫע���� UseDirectoryBrowser() ��˳��UseDefaultFiles������ܵ�֮ǰ����ô���������һ��Ŀ¼��Ҳ��Ĭ�Ϸ��ؾ�̬�ļ�,��������UseDirectoryBrowserһ��ʹ��
app.UseDefaultFiles();
//�����ʵ�·����һ���ļ�Ŀ¼���򷵻�һ��ҳ�棬ҳ������˸�Ŀ¼�������ļ�������
app.UseDirectoryBrowser();
//��̬�ļ�֧�֣�Ĭ��Ŀ¼Ϊwwwroot
app.UseStaticFiles();
//�Զ���Ŀ¼
app.UseStaticFiles(new StaticFileOptions()
{
    RequestPath = "/files",   //�������ã���Ĭ��Ϊ��Ŀ¼
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "file"))
});

//�Զ���·���յ㣬�����в�����apiΪǰ׺·�ɵ�����ȫ�����ؾ�̬�ļ���Ŀ¼��Ĭ���ļ�index.html�����������澲̬�ļ��м��ע����������
//���ԣ����ϴ��ڵľ�̬�ļ�Ŀ¼�ͻ᷵�أ����󲢲����ߵ�����
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
