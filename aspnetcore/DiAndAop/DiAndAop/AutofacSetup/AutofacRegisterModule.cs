using Autofac;
using Autofac.Extras.DynamicProxy;
using DiAndAop.Aop;
using DiAndAop.Generics;
using System.Reflection;

namespace DiAndAop.AutofacSetup
{
    public class AutofacRegisterModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {   //注册Aop需要的拦截器
            builder.RegisterType<LogAop>();
            //泛型
            builder.RegisterGeneric(typeof(BaseService<>))
                .As(typeof(IBaseService<>))
                .InstancePerLifetimeScope();
            //注册程序集
            var asmService = Assembly.Load("AutofacServices");
            builder.RegisterAssemblyTypes(asmService)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LogAop));
        }
    }
}
