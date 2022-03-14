using Microsoft.AspNetCore.Mvc;
using ExceptionHandler.Exceptions;
namespace ExceptionHandler.Controllers;

[ApiController]
[Route("test")]
[MyExceptionFilterAttribute]    //控制器级的异常过滤属性，也可以放在方法上
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }
    /// <summary>
    /// 测试异常过滤器
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {   //模拟应用程序异常
        throw new IOException("XX文件不存在");
        //模拟业务逻辑异常
        throw new MyBusinessException("该账户余额不足，支付失败", 111);

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
