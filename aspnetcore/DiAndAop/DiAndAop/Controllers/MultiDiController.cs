using AutofacServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiAndAop.Controllers
{
    [Route("api/multidi")]
    [ApiController]
    public class MultiDiController : ControllerBase
    {
        private readonly IAddService? addService;
        private readonly ISubService? subService;

        public MultiDiController(IAddService? addService, ISubService? subService)
        {
            this.addService = addService;
            this.subService = subService;
        }

        [HttpGet("add")]
        public int Add(int x,int y)
        {
            return addService.Add(x,y); 
        }
        [HttpGet("sub")]
        public int Sub(int x, int y)
        {
            return subService.Sub(x, y);
        }
    }
}
