
namespace WebApi.Models
{
    public class Portfolio
    {
        public string AppUserId { get; set; }
        public int StockId { get; set; }
        public AppUser appUser { get; set; }
        public Stock stock { get; set; }
    }
}
