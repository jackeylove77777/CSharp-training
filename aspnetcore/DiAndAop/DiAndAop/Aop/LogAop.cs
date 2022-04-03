using Castle.DynamicProxy;

namespace DiAndAop.Aop
{
    public class LogAop : IInterceptor
    {   
        private readonly ILogger<LogAop>? logger;

        public LogAop(ILogger<LogAop>? logger)
        {
            this.logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {   
            string methodName=invocation.TargetType.Name+"-"+invocation.Method.Name;
            logger?.LogInformation(string.Format("开始执行 {0} 方法",methodName));
            try
            {   //执行代理的方法
                invocation.Proceed();
            }catch (Exception ex)
            {
                throw ex;
            }
            logger?.LogInformation("{0}方法执行结束", methodName);
        }
    }
}
