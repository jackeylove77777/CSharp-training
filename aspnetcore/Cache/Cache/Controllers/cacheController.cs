using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using static Cache.MockContext;

namespace Cache.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class cacheController : ControllerBase
    {
        private readonly IMemoryCache cache;
        private readonly MockContext context;
        private readonly IDistributedCache distributedCache;//分布式Redis缓存
        public cacheController(IMemoryCache cache, MockContext context, IDistributedCache distributedCache)
        {
            this.cache = cache;
            this.context = context;
            this.distributedCache = distributedCache;
        }


        //客户端缓存
        [HttpGet("client")]
        //响应体添加cache-control这个header，然后缓存的时间是20秒
        [ResponseCache(Duration = 20)]
        public DateTime Now()
        {
            return DateTime.Now;
        }
        [HttpGet("timer")]
        [ResponseCache(Duration =20)]
        public int getNum()
        {
            return Statics.num;
        }

        [HttpGet("books/{id}")]
        public async Task<Book> getBookById(int id)
        {   
            //GetOrCreateAsync方法会把null值也存入缓存之中，可以防止缓存穿透
            var book =await cache.GetOrCreateAsync("book:" + id.ToString(),async ( entry) =>
            {
                //设置过期绝对过期时间，并且加上随机添加的时间防止缓存雪崩
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20 + Random.Shared.Next(10));
                return context.getBookById(id);
            });
            return book;
        }

        [HttpGet("books")]
        public async Task<ActionResult<List<Book>>> AllBooks()
        {
            var books = new List<Book>();
            string? value = await distributedCache.GetStringAsync("Books");
            if (value == null)
            {
                Console.WriteLine("正在缓存");
                books=context.AllBooks();
                await distributedCache.SetStringAsync("Books", JsonSerializer.Serialize(books));
            }
            else
            {
                books = JsonSerializer.Deserialize<List<Book>>(value);
            }
            //虽然有缓存，但是也有可能缓存的是null
            if (books == null)
            {
                return NotFound();
            }
            else
            {
                return books;
            }
        }

    }
}
