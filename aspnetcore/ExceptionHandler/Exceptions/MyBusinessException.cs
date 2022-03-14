#nullable disable
namespace ExceptionHandler.Exceptions;

/// <summary>
/// 业务逻辑异常实现类
/// </summary>
public class MyBusinessException : Exception, IBusinessException
{
    public MyBusinessException(string message,int ErrorCode,params object[] ErrorData) : base(message)
    {
        this.ErrorCode = ErrorCode;
        this.ErrorData = ErrorData;
    }
    public int ErrorCode { get;private set; }

    public object[] ErrorData { get;private set; }
}