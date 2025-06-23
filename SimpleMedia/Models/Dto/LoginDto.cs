using System.ComponentModel.DataAnnotations;

namespace SimpleMedia.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "請輸入帳號"),Display(Name ="帳號")]
        public string UserID { get; set; } = null!;
        [Required(ErrorMessage = "請輸入密碼"), Display(Name = "密碼")]
        public string Password { get; set; } = null!;

    }
}
