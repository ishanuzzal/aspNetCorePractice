using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.Helpers;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos.Stock;
namespace WebApi.Repository
{
    public class StockRepository : IStockQuery
    {
        ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock> GetStockAsync(int id)
        {
            var s = await _context.Stocks.FindAsync(id);
            return s;

        }

        public async Task<List<Stock>> GetAllAsync(QueryStockPerameter qu)
        {
            var result= _context.Stocks.Include(X=>X.Comments).AsQueryable();
            if (!String.IsNullOrEmpty(qu.CompanyName))
            {
                result = result.Where(r => r.CompanyName.Contains(qu.CompanyName));
            }
            return await result.ToListAsync();
        }

        public Task<bool> StockExist(int id)
        {
            return _context.Stocks.AnyAsync(x => x.Id == id);
        }

        public async Task<Stock> UpdateStockById(int id, UpdateStockDto dto)
        {
            var stock = await _context.Stocks.FindAsync(id);
            stock.CompanyName = dto.CompanyName;
            stock.Industry = dto.Industry;
            await _context.SaveChangesAsync();
            return stock;
        }
    }
}
