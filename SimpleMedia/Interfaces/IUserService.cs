using SimpleMedia.Dto;
using SimpleMedia.Entities;

namespace SimpleMedia.Interfaces
{
    public interface IUserService
    {
        Task<ProfileDto> GetProfileAsync(string userId);
        Task UpdateProfileAsync(ProfileDto u, string userId);
        Task<bool> UserExistsAsync(string userId);
        Task RegisterProfileAsync(User user);

    }
}
