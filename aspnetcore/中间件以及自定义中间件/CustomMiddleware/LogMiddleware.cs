namespace 中间件以及自定义中间件.CustomMiddleware;
/// <summary>
/// 这是一种约定俗称的自定义中间件的方式，即通过构造函数注入请求管道中下一个中间件的Invoke调用
/// 然后定义工作方法 InvokeAsync
/// </summary>
public class LogMiddleware
{
    private readonly ILogger logger;
    private readonly RequestDelegate next;

    public LogMiddleware(ILogger<LogMiddleware> logger, RequestDelegate next)
    {
        this.logger = logger;
        this.next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        using (logger.BeginScope("TraceIdentifier:{TraceIdentifire}", httpContext.TraceIdentifier))
        {
            logger.LogInformation("开始执行{0}", next.Method.Name);
            await next(httpContext);
            logger.LogInformation("结束执行{0}", next.Method.Name);
        }
    }
}