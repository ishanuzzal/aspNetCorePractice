using WebApi.Models;
using WebApi.Helpers;
using WebApi.Dtos.Stock;
namespace WebApi.Interfaces
{
    public interface IStockQuery
    {
        public Task<List<Stock>> GetAllAsync(QueryStockPerameter qu);
        public Task<Stock> CreateAsync(Stock stock);
        public Task<bool> StockExist(int id);
        public Task<Stock> GetStockAsync(int id);
        public Task<Stock> UpdateStockById(int id,UpdateStockDto dto);
    }
}
