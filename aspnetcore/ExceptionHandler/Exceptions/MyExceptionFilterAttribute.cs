namespace ExceptionHandler.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
public class MyExceptionFilterAttribute:ExceptionFilterAttribute{

    public override void OnException(ExceptionContext context){
        IBusinessException exception = context.Exception as IBusinessException;
        //若为null,则表明不是自定义的业务逻辑异常
        if(exception is null){
            var logger = context.HttpContext.RequestServices.GetService<ILogger<ExceptionFilter>>();
            logger.LogError(context.Exception, context.Exception.Message);
            exception = BusinessException.UnknowException;
            //若为应用程序异常，http状态码设为500
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }else{
            
            exception = BusinessException.FromBusinessException(exception);
            //若为业务逻辑异常，则http状态码设为200，这不是应用程序出错导致的异常，不应该设为500
            context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
        }

        context.Result = new JsonResult(exception)
        {
            ContentType="application/json; charset=utf-8"
        };

    }
}