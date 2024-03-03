using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICommentQuery
    {
        public Task<List<Comment>> GetAllAsync();
        public Task<Comment> CreateAsync(Comment comment);
    }
}
