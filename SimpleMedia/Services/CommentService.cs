using SimpleMedia.Entities;
using SimpleMedia.Interfaces;
using SimpleMedia.Models.Dto;

namespace SimpleMedia.Services
{
    public class CommentService : ICommentService
    {
        private readonly SimpleMediaContext _context;

        public CommentService(SimpleMediaContext context)
        {
            _context = context;
        }

        public async Task CreateCommentAsync(Comment comment,string userId)
        {

            comment.LastMaintainDt = DateTime.Now;
            comment.UserID = userId;

            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(EditCommentDto Content, int commentID)
        {
            var comment = _context.Comment.Find(commentID);
            comment.Content = Content.Content;
            comment.LastMaintainDt = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int commentID)
        {
            var comment = _context.Comment.Find(commentID);
             _context.Comment.Remove(comment);

            await _context.SaveChangesAsync();
        }
    }
}
