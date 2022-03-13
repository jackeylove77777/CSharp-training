namespace 中间件以及自定义中间件.MiddleExtensions;
public static class AddCustomMiddleware
    {
        /// <summary>
        /// 定义webapp的拓展方法注册中间件
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public static WebApplication UseCustomLog(this WebApplication application)
        {
            application.UseMiddleware<LogMiddleware>();
            return application;
        }
    }