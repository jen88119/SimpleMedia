using SimpleMedia.Dto;

namespace SimpleMedia.Interfaces
{
    public interface IPostService
    {
        Task<List<QueryPostDto>> GetAllPostsAsync();
        Task CreatePostAsync(CreatePostDto post, string userId);
        Task<QueryPostDto> GetAllDetailAsync(int id);
        Task<EditPostDto> GetPostContentAsync(int id);
        Task UpdatePostAsync(EditPostDto post);
        Task DeletePostAsync(int id);
    }
}
