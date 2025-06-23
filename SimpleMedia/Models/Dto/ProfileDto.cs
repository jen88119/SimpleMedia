using System.ComponentModel.DataAnnotations;

namespace SimpleMedia.Dto
{
    public class ProfileDto
    {

        [Required(ErrorMessage ="請輸入帳號")]
        public string UserID { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required,EmailAddress]
        public string Email { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? Salt { get; set; }
        public byte[]? CoverImage { get; set; }
        [Required]
        public string? Biography { get; set; }
    }
}
