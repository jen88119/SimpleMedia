using Microsoft.EntityFrameworkCore;
using SimpleMedia.Dto;
using SimpleMedia.Entities;
using SimpleMedia.Interfaces;
using SimpleMedia.Models.Dto;
using System.Data;

namespace SimpleMedia.Services
{
    public class PostService : IPostService
    {
        private readonly SimpleMediaContext _context;

        public PostService(SimpleMediaContext context)
        {
            _context = context;
        }

        public async Task<List<QueryPostDto>> GetAllPostsAsync()
        {
            return await _context.Post
                .Include(p => p.User)
                .OrderByDescending(p => p.LastMaintainDt)
                .Select(p => new QueryPostDto
                {
                    UserID = p.UserID,
                    PostID = p.PostID,
                    UserName = p.User.UserName,
                    Content = p.Content,
                    LastMaintainDt = p.LastMaintainDt
                })
                .ToListAsync();
        }

        public async Task CreatePostAsync(CreatePostDto post, string userId)
        {
            var p = new Post
            {
                UserID = userId,
                Content = post.Content,
                LastMaintainDt = DateTime.Now
            };

            _context.Post.Add(p);
            await _context.SaveChangesAsync();
        }

        public async Task<QueryPostDto> GetAllDetailAsync(int id)
        {
            var detail = await _context.Post
               .Include(p => p.User)
               .Include(p => p.Comment)
                   .ThenInclude(c => c.User)
               .Where(p => p.PostID == id)
               .Select(p => new QueryPostDto
               {
                   UserID = p.UserID,
                   PostID = p.PostID,
                   UserName = p.User.UserName,
                   Content = p.Content,
                   LastMaintainDt = p.LastMaintainDt,
                   Comments = p.Comment
                       .OrderByDescending(c => c.LastMaintainDt)
                       .Select(c => new QueryCommentDto
                       {
                           CommentID = c.CommentID,
                           UserID = c.UserID,
                           UserName = c.User.UserName,
                           Content = c.Content,
                           LastMaintainDt = c.LastMaintainDt
                       }).ToList()
               })
               .FirstOrDefaultAsync();

            return detail;
        }

        public async Task<EditPostDto> GetPostContentAsync(int id)
        {
            var post = await _context.Post.FindAsync(id);

            if (post == null)
            {
                return null;
            }

            var editDto = new EditPostDto
            {
                PostID = post.PostID,
                UserID = post.UserID,
                Content = post.Content,
                Image = null
            };

            return editDto;
        }


        public async Task UpdatePostAsync(EditPostDto post)
        {
            var p = _context.Post.Find(post.PostID);

            p.Content = post.Content;
            p.LastMaintainDt = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var delete = _context.Post
                .Where(a => a.PostID == id)
                .Include(a => a.Comment).SingleOrDefault();

            _context.Post.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }
}
