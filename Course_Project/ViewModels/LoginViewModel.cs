using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Web_Project.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "{0} نمی تواند خالی باشد")]
        public string Username { get; set; } = string.Empty;

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "{0} نمی تواند خالی باشد")]
        public string Password { get; set; } = string.Empty;

        [DisplayName("مرا به خاطر بسپار")]
        public bool RememberMe { get; set; } = false;
    }
}
