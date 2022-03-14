namespace ExceptionHandler.Exceptions;

/// <summary>
/// 过滤业务逻辑异常或者应用程序异常的显示，不能让用户或者前端看到这些非必要的信息
/// </summary>
public class BusinessException:IBusinessException{
    
    public static IBusinessException FromBusinessException(IBusinessException exception){
        return new BusinessException(exception.Message, exception.ErrorCode, exception.ErrorData);
    }
    public static readonly IBusinessException UnknowException = new BusinessException("未知错误", 156);

    private BusinessException(string message,int errorCode,params object[] errorData)
    {
        ErrorCode = errorCode;
        ErrorData = errorData;
        Message = message;
    }

    public int ErrorCode { get;private set; }

    public object[] ErrorData { get;private set; }
    public string Message{ get; private set; }
}