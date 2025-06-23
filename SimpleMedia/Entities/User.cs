using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMedia.Entities
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            Post = new HashSet<Post>();
        }

        [Required(ErrorMessage ="請輸入帳號")]
        public string UserID { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required,EmailAddress]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; } = null!;
        public string? Salt { get; set; }
        public byte[]? CoverImage { get; set; }
        [Required]
        public string? Biography { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
