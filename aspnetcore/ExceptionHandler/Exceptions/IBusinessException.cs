namespace ExceptionHandler.Exceptions;

/// <summary>
/// 自定义业务逻辑异常接口
/// </summary>
public interface IBusinessException
{   public string Message{ get; }
    public int ErrorCode { get; }

    public object[] ErrorData { get; }
}