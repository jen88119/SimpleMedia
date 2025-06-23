using Microsoft.EntityFrameworkCore;
using SimpleMedia.Dto;
using SimpleMedia.Entities;
using SimpleMedia.Interfaces;
using SimpleMedia.Models;
using SimpleMedia.Models.Dto;
using System.Data;

namespace SimpleMedia.Services
{
    public class UserService : IUserService
    {
        private readonly SimpleMediaContext _context;

        public UserService(SimpleMediaContext context)
        {
            _context = context;
        }

        public async Task<ProfileDto> GetProfileAsync(string userId)
        {
            var user =await _context.User.FindAsync(userId);

            ProfileDto p = new ProfileDto
            {
                UserID = user.UserID,
                UserName = user.UserName,
                Email = user.Email,
                Biography = user.Biography
            };

            return p;
        }

        public async Task UpdateProfileAsync(ProfileDto u,string userId)
        {
            var user = _context.User.Find(userId);

            user.UserName = u.UserName;
            user.Biography = u.Biography;

            if (!string.IsNullOrWhiteSpace(u.Password))
            {
                string salt = PasswordHelper.GenerateSalt();
                string hashedPassword = PasswordHelper.HashPassword(u.Password, salt);
                user.Password = hashedPassword;
                user.Salt = salt;
            }
            await _context.SaveChangesAsync();

        }

        public async Task<bool> UserExistsAsync(string userId)
        {
            return await _context.User.AnyAsync(a => a.UserID == userId);
        }

        public async Task RegisterProfileAsync(User user)
        {
            string salt = PasswordHelper.GenerateSalt();
            string hashedPassword = PasswordHelper.HashPassword(user.Password, salt);

            User u = new User
            {
                UserID = user.UserID,
                Password = hashedPassword,
                UserName = user.UserName,
                Email = user.Email,
                Biography = user.Biography,
                Salt = salt
            };

            _context.Add(u);
            await _context.SaveChangesAsync();
        }
    }
}
