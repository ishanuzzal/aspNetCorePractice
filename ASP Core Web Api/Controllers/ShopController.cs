using ASP_Core_Web_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Core_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : Controller
    {
        private readonly ShopDBContext _dbContext;
        public ShopController(ShopDBContext db)
        {
            _dbContext = db;
        }
        [HttpGet]
        public string Index()
        {
            return "hello world";
        }

        [HttpPost]
        public async Task<ActionResult<Order>> createOrder(Order order) 
        {
            var b = await _dbContext.AddAsync(order);
            var a = await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(order).ReloadAsync();
            return Ok(order);
        }
    }
}
