using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IportfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser user);
    }
}
