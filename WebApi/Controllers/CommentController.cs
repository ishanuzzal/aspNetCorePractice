using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos.Comment;
using WebApi.Extention;
using WebApi.Interfaces;
using WebApi.Mappers;
using WebApi.Models;
namespace WebApi.Controllers
{
    [Route("api/Comment")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommentQuery _commentRepo;
        private readonly IStockQuery _stockRepo;
        private readonly UserManager<AppUser> _appuser;
        public CommentController(ApplicationDbContext db, ICommentQuery commentRepo,IStockQuery stockRepo,UserManager<AppUser> appuser)
        {
            _context = db;
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
            _appuser = appuser;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comment = await _commentRepo.GetAllAsync();
            var c = comment.Select(s => s.ToCommentDto());
            return Ok(c);
        }

        [HttpPost("{stockId}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] int stockId,[FromBody] CreateCommentDto dto)
        {
            if(!await _stockRepo.StockExist(stockId)){
                return BadRequest("not found");
            }

            var username = User.GetUsername();
            var appUser = await _appuser.FindByNameAsync(username);

            var model = dto.ToCommentModelCreate(stockId);
            model.UserId = appUser.Id;
            await _commentRepo.CreateAsync(model);
            return CreatedAtAction(nameof(Create), new { id = model.Id }, model.ToCommentDto());
        }

    }
}

