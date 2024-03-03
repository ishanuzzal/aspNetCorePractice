using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;
namespace WebApi.Repository
{
    public class CommentRepository : ICommentQuery
    {
        public readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext db) {
            _context = db;
        }
        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.comments.ToListAsync();

        }
    }
}
