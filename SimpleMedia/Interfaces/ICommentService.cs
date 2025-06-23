using SimpleMedia.Dto;
using SimpleMedia.Entities;
using SimpleMedia.Models.Dto;

namespace SimpleMedia.Interfaces
{
    public interface ICommentService
    {
        Task CreateCommentAsync(Comment comment,string userId);
        Task UpdateCommentAsync(EditCommentDto Content, int commentID);
        Task DeleteCommentAsync(int commentID);

    }
}
