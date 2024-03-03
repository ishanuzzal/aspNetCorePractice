using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos.Stock;
using WebApi.Interfaces;
using WebApi.Mappers;
using WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
namespace WebApi.Controllers
{
    [Route("api/Stock")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockQuery _stockRepo;
        public StockController(ApplicationDbContext db,IStockQuery stockRepo) {
            _context = db;
            _stockRepo = stockRepo;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryStockPerameter qu) {
            var stocks = await _stockRepo.GetAllAsync(qu);
            var stock =  stocks.Select(s=>s.ToStockDto());
            return Ok(stocks);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto dto)
        {
            var model = dto.ToStockFromCreateDTO();
            await _stockRepo.CreateAsync(model);
            return CreatedAtAction(nameof(Create),new {id = model.Id},model.ToStockDto());
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetStockById(int id)
        {
            if (await _stockRepo.StockExist(id)==false) return NotFound();
            var model = await _stockRepo.GetStockAsync(id);
            if (model == null) return NotFound();
            return Ok(model);
        }

        [HttpPut]
        [Route("/id:int")]
        public async Task<IActionResult> UpdateStock([FromRoute]int id,[FromBody] UpdateStockDto info)
        {
            if (await _stockRepo.StockExist(id) == false) return NotFound();
            var model =  await _stockRepo.UpdateStockById(id,info);
            var updateInfo = model.ToStockDto();
            return Ok(updateInfo);
        }

    }
}
