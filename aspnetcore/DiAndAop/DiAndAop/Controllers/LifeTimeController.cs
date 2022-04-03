using DiAndAop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiAndAop.Controllers
{
    [Route("api/life")]
    [ApiController]
    public class LifeTimeController : ControllerBase
    {   
        public record struct LifeAns(int singleHashCode,int scopeHashCode);
        [HttpGet]
        public LifeAns testLife([FromServices] SingletonServ singleton1,[FromServices] SingletonServ singleton2,
            [FromServices] ScopeServ scope1,[FromServices] ScopeServ scope2,
            [FromServices] TransientServ transient1,[FromServices] TransientServ transient2)
        {
            Console.WriteLine(singleton1 ==singleton2);//一直都是True
            Console.WriteLine(singleton1 ==singleton2);//一直都是True
            Console.WriteLine(scope1 == scope2);//一直都是True
            Console.WriteLine(transient1 == transient2);//一直都是False;
            //通过返回的HashCode观察两次请求的HashCode，可发现第一个总是不变的，而第二个一直在改变
            return new LifeAns(singleton1.GetHashCode(),scope1.GetHashCode());
        }

    }
}
