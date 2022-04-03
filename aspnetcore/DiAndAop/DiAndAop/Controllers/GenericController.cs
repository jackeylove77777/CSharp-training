using DiAndAop.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiAndAop.Controllers
{
    [Route("api/generic")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly IBaseService<string>? stringService;
        private readonly IBaseService<Random>? randomService;

        public GenericController(IBaseService<string>? stringService, IBaseService<Random>? randomService)
        {
            this.stringService = stringService;
            this.randomService = randomService;
        }
        [HttpGet]
        public int Test()
        {
            stringService?.PrintT("123");
            //stringService?.PrintT(new Random(4989899));Error
            randomService?.PrintT(new Random(12449849));
            return 1;
        }
    }
}
