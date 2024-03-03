namespace WebApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? StockId { get; set; }
        public Stock? Stock { get; set; }

        public string? UserId { get; set; }
        public AppUser? User { get; set; }

    }
}
