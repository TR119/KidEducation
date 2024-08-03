using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace KidEducation.Core.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Nhập tài khoản")]
        [DisplayName("Tài khoản")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage ="Nhập mật khẩu")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; } = string.Empty;
    }
}
