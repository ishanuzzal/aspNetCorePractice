
namespace WebApi.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? StockId { get; set; }
    }
}
