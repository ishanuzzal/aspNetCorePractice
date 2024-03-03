using System.Runtime.CompilerServices;
using WebApi.Dtos.Comment;
using WebApi.Models;

namespace WebApi.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Title = comment.Title,
                StockId = comment.StockId,
            };
        }
        public static Comment ToCommentModel(this CommentDto commentModel)
        {
            return new Comment
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                StockId = commentModel.StockId,
            };
        }

        public static Comment ToCommentModelCreate(this CreateCommentDto commentModel,int id)
        {
            return new Comment
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                StockId = id,
            };
        }
    }
}
