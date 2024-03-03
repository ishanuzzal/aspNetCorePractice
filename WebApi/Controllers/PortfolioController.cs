using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using WebApi.Extention;
namespace WebApi.Controllers
{
    [Route("api/Portfolio")]
    [ApiController]
    public class PortfolioController:ControllerBase
    {
        private readonly IStockQuery _stockQuery;
        private readonly UserManager<AppUser> _userManager;
        private readonly IportfolioRepository _portfolioRepository;
        public PortfolioController(UserManager<AppUser> userManager, IStockQuery stockQuery, IportfolioRepository portfolioRepository)
        {
            _userManager = userManager;
            _stockQuery = stockQuery;
            _portfolioRepository = portfolioRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var userName = User.GetUsername();
            Console.WriteLine(userName+"  dfdfdfdsfds");
            var appUser = await _userManager.FindByNameAsync(userName);
            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }
    }
}
